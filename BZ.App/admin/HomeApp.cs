using BZ.Common;
using BZ.Domain.admin;
using BZ.Repository.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.App.admin
{
    public class HomeApp : BaseApp
    {
        /// <summary>
        /// 当前操作模块
        /// </summary>
        const string OPT_MODEL = "Login|用户登陆";

        HomeRep _homeRep = new HomeRep();
 
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        public JsonMessage GetMenuList()
        {
            JsonMessage jsonMsg = new JsonMessage();
            int result = 1;
            List<MenuTreeModel> toSource = new List<MenuTreeModel>();
            //List<MenuTreeModel> toSource = (List<MenuTreeModel>)CacheHelper.GetCache("MenuTreeJson");//获取缓存中的数据
            //if (toSource == null)
            //{
            try
            {
                DataTable dt = _homeRep.GetMenuByPersonId(UserID);//获取当前用户所有权限
                List<MenuTreeModel> list_fo = ConverHelper.ToList<MenuTreeModel>(dt).ToList();//转换成List形式
                toSource = new List<MenuTreeModel>();
                var list = list_fo.FindAll(p => p.parent_id == "0");//获取根节点数据
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        GetMenuTreeJson(item, item.id, list_fo);//调用递归
                        toSource.Add(item);//添加到集合中
                    }
                }
                jsonMsg = ServiceResult.Message(1, "菜单获取成功", toSource);
            }
            catch(CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, "系统异常，菜单列表加载失败", toSource);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "左侧菜单列表加载失败，请刷新尝试");
            }

            return jsonMsg;
        }
        /// <summary>
        /// 递归，无限树
        /// </summary>
        /// <param name="toSource"></param>
        /// <param name="parent_id"></param>
        /// <param name="foSource"></param>
        private void GetMenuTreeJson(MenuTreeModel toSource, string parent_id, List<MenuTreeModel> foSource)
        {
            var list = foSource.FindAll(p => p.parent_id == parent_id);
            if (list.Count > 0)
            {
                toSource.children = new List<MenuTreeModel>();
                foreach (var item in list)
                {
                    GetMenuTreeJson(item, item.id, foSource);
                    toSource.children.Add(item);
                }
            }
        }


        public IList<SysMenuModel> GetMenuByUserId(string userId, string parentId)
        {
            DataTable dt = _homeRep.GetMenuByUserId(userId, parentId);
            IList<SysMenuModel> list = ConverHelper.ToList<SysMenuModel>(dt);
            return list;
        }

        /// <summary>
        /// 获取移动端用户菜单列表 WebApi用
        /// </summary>
        /// <returns></returns>
        public JsonMessage GetMobileMenuList(string user_id)
        {
            JsonMessage jsonMsg = new JsonMessage();
            int result = 1;
            List<MenuTreeModel> toSource = new List<MenuTreeModel>(); 
            try
            {
                DataTable dt = _homeRep.GetMobileMenuByUserId(user_id);//获取当前用户所有权限
                List<MenuTreeModel> list_fo = ConverHelper.ToList<MenuTreeModel>(dt).ToList();//转换成List形式
                toSource = new List<MenuTreeModel>();
                var list = list_fo.FindAll(p => p.parent_id == "1");//获取根节点数据
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        GetMenuTreeJson(item, item.id, list_fo);//调用递归
                        toSource.Add(item);//添加到集合中
                    }
                }
                jsonMsg = ServiceResult.Message(1, "菜单获取成功", toSource);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(0, "系统异常，菜单列表加载失败", toSource);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "左侧菜单列表加载失败，请刷新尝试");
            }

            return jsonMsg;
        }

    }
}
