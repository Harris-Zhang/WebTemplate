using BZ.App.admin;
using BZ.Common;
using BZ.Domain.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Core
{
    /// <summary>
    /// 权限验证 过滤器
    /// </summary>
    public class RightFilterAttribute : ActionFilterAttribute
    {
        public string ActionName { get; set; }
        private string Area;

        /// <summary>
        /// Action加上[SupportFilter]在执行actin之前执行以下代码，通过[SupportFilter(ActionName="Index")]指定参数
        /// </summary>
        /// <param name="filterContext">页面传过来的上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //读取请求上下文中的Controller,Action,Id
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            RouteData routeData = routes.GetRouteData(filterContext.HttpContext);
            //取出区域的控制器Action,id
            string ctlName = filterContext.Controller.ToString();
            string[] routeInfo = ctlName.Split('.');
            string controller = null;
            string action = null;
            string id = null;

            int iAreas = Array.IndexOf(routeInfo, "Areas");
            if (iAreas > 0)
            {
                //取区域及控制器
                Area = routeInfo[iAreas + 1];
            }
            //int ctlIndex = Array.IndexOf(routeInfo, "Controllers");
            //ctlIndex++;
            int ctlIndex = routeInfo.Length - 1;
            controller = routeInfo[ctlIndex].Replace("Controller", "").ToLower();

            string url = HttpContext.Current.Request.Url.ToString().ToLower();
            string[] urlArray = url.Split('/');
            int urlCtlIndex = Array.IndexOf(urlArray, controller);
            urlCtlIndex++;
            if (urlArray.Count() > urlCtlIndex)
            {
                action = urlArray[urlCtlIndex];
            }
            urlCtlIndex++;
            if (urlArray.Count() > urlCtlIndex)
            {
                id = urlArray[urlCtlIndex];
            }
            //url
            action = ValidateHelper.IsNullOrEmpty(action) ? "Index" : action;
            int actionIndex = action.IndexOf("?", 0);
            if (actionIndex > 1)
            {
                action = action.Substring(0, actionIndex);
            }
            id = ValidateHelper.IsNullOrEmpty(id) ? "" : id;

            //URL路径
            string actionPath = HttpContext.Current.Request.FilePath;
            if (filterContext.HttpContext.Request.UrlReferrer == null)
            {
                filterContext.Result = new EmptyResult();
                string js = "<script language='javascript'>alert('{0}');</script>";
                filterContext.HttpContext.Response.Write(string.Format(js, "你没有操作权限，请联系管理员"));
                filterContext.HttpContext.Response.End();
                return;
            }
            string filePath = filterContext.HttpContext.Request.UrlReferrer.AbsolutePath;
            AccountModel account = filterContext.HttpContext.Session["Account"] as AccountModel;
            if (ValiddatePermission(account, controller, action, actionPath, filePath))
            {
                return;
            }
            else
            {
                filterContext.Result = new EmptyResult();
                filterContext.HttpContext.Response.ContentType = "application/json";
                JsonMessage jsonMsg = ServiceResult.Message(0, "你没有操作权限，请联系管理员");
                filterContext.HttpContext.Response.Write("{\"type\":0,\"message\":\"你没有操作权限，请联系管理员\"}");
                filterContext.HttpContext.Response.End();
                return;
            }
        }
        public bool ValiddatePermission(AccountModel account, string controller, string action, string actionPath, string filePath)
        {
            bool bResult = false;
            string actionName = ValidateHelper.IsNullOrEmpty(ActionName) ? action : ActionName;
            if (account != null)
            {
                IList<permModel> perm = null;
                //测试当前controller是否已赋权限值，如果没有从
                //如果存在区域,Seesion保存（区域+控制器）
                if (!ValidateHelper.IsNullOrEmpty(Area))
                {
                    controller = Area + "/" + controller;
                }
                perm = (List<permModel>)HttpContext.Current.Session[account.UserCode + ":" + filePath];
                if (perm == null)
                {
                    SysRightApp _appRole = new SysRightApp();
                    perm = _appRole.GetPermission(account.UserCode, filePath);//获取当前用户的权限列表
                    HttpContext.Current.Session[account.UserCode + ":" + filePath] = perm;//获取的劝降放入会话由Controller调用

                }
                //当用户访问index时，只要权限>0就可以访问
                if (actionName.ToLower() == "index")
                {
                    if (perm.Count > 0)
                    {
                        return true;
                    }
                }
                //查询当前Action 是否有操作权限，大于0表示有，否则没有
                int count = perm.Where(a => a.KEYCODE.ToLower() == actionName.ToLower()).Count();
                if (count > 0)
                {
                    bResult = true;
                }
                else
                {
                    bResult = false;

                }

            }
            return bResult;
        }
    }
}