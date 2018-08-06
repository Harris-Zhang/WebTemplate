using BZ.Common;
using BZ.Domain.admin;
using BZ.Repository.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.App.admin
{
    public class SysMenuApp : BaseApp
    {
        /// <summary>
        /// 当前操作模块
        /// </summary>
        const string OPT_MODEL = "SysMenu|菜单管理";

        SysMenuRep _menuRep = new SysMenuRep();
        SysMenuOptRep _menuOptRep = new SysMenuOptRep();
        SysRightRep _rightRep = new SysRightRep();

        public JsonMessage Insert(string menuName, string parentId, string code, string link, string icon, int sort, string type, string desc, bool isable, bool isend)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            _menuRep.BeginTransaction();
            try
            {
                DataTable dt = _menuRep.GetByCodeOrName(code, menuName);
                if (!ValidateHelper.IsDataTableNotData(dt))
                {
                    throw new CustomException(0, "添加失败，菜单名称或编码已存在");
                }

                SysMenuModel model = new SysMenuModel();
                model.MENU_ID = GuidHelper.GenerateComb().ToString().ToUpper();
                model.MENU_NAME = menuName;
                model.PARENT_ID = parentId;
                model.MENU_CODE = code;
                model.MENU_PATH = link;
                model.MENU_ICON = icon;
                model.MENU_SORT = sort;
                model.MENU_TYPE = type;
                model.MENU_DESC = desc;
                model.IS_ABLED = isable ? 1 : 0;
                model.IS_END = isend ? 1 : 0;
                model.CREATE_USER = UserID;
                model.LM_USER = UserID;

                result = _menuRep.Insert(model);
                if (result == 1)
                {
                    SysMenuOptModel optModel = new SysMenuOptModel();
                    optModel.MO_CODE = "browse";
                    optModel.MO_NAME = "浏览";
                    optModel.MENU_ID = model.MENU_ID;
                    optModel.IS_ABLED = 1;
                    optModel.MO_DESC = "请勿删除，默认添加项，误删除请重新添加上";
                    optModel.CREATE_USER = UserID;
                    optModel.LM_USER = UserID;
                    _menuOptRep.Insert(optModel);
                    _rightRep.InsertSysRight(model.CREATE_USER, model.LM_USER);
                }
                _menuRep.CommitTransaction();

                jsonMsg = ServiceResult.Message(1, "菜单添加成功");
            }
            catch(CustomException ex)
            {
                _menuRep.RollbackTransaction();
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                _menuRep.RollbackTransaction();
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, code + ":添加系统菜单失败");
            } 

            //写入log
            WriteSystemLog(jsonMsg, CREATE, OPT_MODEL, code + ":添加系统菜单");

            return jsonMsg;

        }

        public JsonMessage Delete(string menuId)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                DataTable dt = _menuRep.GetList(menuId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    throw new CustomException(0, "该菜单下有子菜单，请先删除子菜单 ");//该菜单下有子菜单，请先删除子菜单 
                }
                result = _menuRep.Delete(menuId);
                if (result > 0)
                {
                    _rightRep.ClearUnusedRightOpt();
                }

                jsonMsg = ServiceResult.Message(1, "菜单删除成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, menuId + ":删除系统菜单失败");
            } 
            //写入log
            WriteSystemLog(jsonMsg, DELETE, OPT_MODEL, menuId + ":删除系统菜单");

            return jsonMsg;

        }
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="menuName"></param>
        /// <param name="parentId"></param>
        /// <param name="code"></param>
        /// <param name="link"></param>
        /// <param name="icon"></param>
        /// <param name="sort"></param>
        /// <param name="type"></param>
        /// <param name="desc"></param>
        /// <param name="isable"></param>
        /// <param name="isend"></param>
        /// <returns></returns>
        public JsonMessage Edit(string menuId, string menuName, string parentId, string code, string link, string icon, int sort, string type, string desc, bool isable, bool isend)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                DataTable dt= _menuRep.GetById(menuId);
                if(ValidateHelper.IsDataTableNotData(dt))
                {
                    throw new CustomException(0, "菜单不存在，刷新后尝试");
                }
                SysMenuModel model = new SysMenuModel();
                model.MENU_ID = menuId;
                model.MENU_NAME = menuName;
                model.PARENT_ID = parentId;
                model.MENU_CODE = code;
                model.MENU_PATH = link;
                model.MENU_ICON = icon;
                model.MENU_SORT = sort;
                model.MENU_TYPE = type;
                model.MENU_DESC = desc;
                model.IS_ABLED = isable ? 1 : 0;
                model.IS_END = isend ? 1 : 0;
                model.CREATE_USER = UserID;
                model.LM_USER = UserID;
                result = _menuRep.Edit(model);

                jsonMsg = ServiceResult.Message(1, "菜单修改成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, menuId + ":修改系统菜单失败");
            } 

            //写入log
            WriteSystemLog(jsonMsg, UPDATE, OPT_MODEL, menuId + ":修改系统菜单");

            return jsonMsg;

        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IList<SysMenuModel> GetList(string parentId)
        {
            DataTable dt = _menuRep.GetList(parentId);
            IList<SysMenuModel> list = ConverHelper.ToList<SysMenuModel>(dt);
            return list;
        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IList<SysMenuModel> GetParentList(string parentId)
        {
            DataTable dt = _menuRep.GetParentList(parentId);
            IList<SysMenuModel> list = ConverHelper.ToList<SysMenuModel>(dt);
            return list;
        }
        /// <summary>
        /// 获取菜单明细
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public SysMenuModel GetById(string menuId)
        {
            DataTable dt = _menuRep.GetById(menuId);
            IList<SysMenuModel> list = ConverHelper.ToList<SysMenuModel>(dt);
            if (list.Count > 0)
                return list[0];
            return null;
        }

        /// <summary>
        /// 根据角色获取菜单列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IList<SysMenuModel> GetListByRoleId(string roleId, string parentId)
        {
            DataTable dt = _menuRep.GetListByRoleId(roleId, parentId);
            IList<SysMenuModel> list = ConverHelper.ToList<SysMenuModel>(dt);
            return list;
        }

        /// <summary>
        /// 获取服务器文件目录
        /// </summary>
        /// <param name="rootUrl">html上级目录</param>
        /// <returns></returns>
        public IList<SysMenuPath> GetConPath(string rootUrl)
        {
            IList<SysMenuPath> list = new List<SysMenuPath>();

            string dirPath = System.Web.HttpContext.Current.Server.MapPath(rootUrl);//转换物理地址
            if (Directory.Exists(dirPath))
            {
                //获得目录信息
                DirectoryInfo dir = new DirectoryInfo(dirPath);

                DirectoryInfo[] ch_dir = dir.GetDirectories();//是否有文件夹

                foreach (DirectoryInfo info in ch_dir)//循环文件夹
                {
                    SysMenuPath mp = new SysMenuPath();
                    mp.PATH_ID = (rootUrl + "/" + info.Name).Replace("/", "replace_lp");//因为“\” 有问题，替换掉
                    mp.PATH_URL = rootUrl + "/" + info.Name;
                    mp.PATH_NAME = info.Name;
                    mp.PATH_TYPE = "Folder";
                    list.Add(mp);
                }

                //获得目录文件列表
                FileInfo[] files = dir.GetFiles("*.htm").Where(s =>s.Extension==".htm").ToArray();//查询*.htm 文件

                foreach (FileInfo fileInfo in files)
                {
                    SysMenuPath mp = new SysMenuPath();
                    mp.PATH_ID = (rootUrl + "/" + fileInfo.Name).Replace("/", "replace_lp").Replace(".htm", "replace_pp"); //因为 “.”有问题，和.htm 一起替换掉
                    mp.PATH_URL = rootUrl + "/" + fileInfo.Name;
                    mp.PATH_NAME = fileInfo.Name;
                    mp.PATH_TYPE = "File";
                    list.Add(mp);
                }
                return list;

            }
            return null;
        }

    }
}
