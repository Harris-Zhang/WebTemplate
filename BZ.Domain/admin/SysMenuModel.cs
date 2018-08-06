using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{
    /// <summary>
    //系统菜单管理
    /// </summary>	
    [Serializable]
    public class SysMenuModel
    {
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>		
        public string MENU_ID { get; set; }
        /// <summary>
        /// MENU_CODE
        /// </summary>		
        public string MENU_CODE { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>		
        public string MENU_NAME { get; set; }
        /// <summary>
        /// 页面路径
        /// </summary>		
        public string MENU_PATH { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>		
        public string MENU_ICON { get; set; }
        /// <summary>
        /// 菜单排序
        /// </summary>		
        public decimal MENU_SORT { get; set; }
        /// <summary>
        /// MENU_DESC
        /// </summary>		
        public string MENU_DESC { get; set; }
        /// <summary>
        /// 页面运行环境
        /// </summary>		
        public string MENU_TYPE { get; set; }
        /// <summary>
        /// 是否可见
        /// </summary>		
        public int IS_ABLED { get; set; }
        /// <summary>
        /// 是否是最后一项
        /// </summary>		
        public int IS_END { get; set; }
        /// <summary>
        /// 父菜单ID
        /// </summary>		
        public string PARENT_ID { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>		
        public string CREATE_USER { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>		
        public DateTime LM_TIME { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>		
        public string LM_USER { get; set; }

        public string state { get; set; }//treegrid
    }

    public class SysMenuPath
    {
        public string PATH_ID { get; set; }

        public string PATH_URL { get; set; }

        public string PATH_NAME { get; set; }

        public string PATH_TYPE { get; set; }

        public string state { get; set; }//treegrid
    }

    /// <summary>
    /// 菜单树json格式
    /// </summary>
    public class MenuTreeModel
    {
        /// <summary>
        /// ID 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public string parent_id { get; set; }
        /// <summary>
        /// 显示文本
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 打开类别
        /// </summary>
        public string targetType { get; set; }
        /// <summary>
        /// 子类
        /// </summary>
        public List<MenuTreeModel> children { get; set; }
    }

    /// <summary>
    ///  jqGrid 树表参数
    /// </summary>
    public class jqGridModel
    {
        /// <summary>
        /// 节点层级
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 表示此数据是否为叶子节点
        /// </summary>
        public bool isLeaf { get; set; }
        /// <summary>
        ///  表示父节点是哪个，如果当前节点为父节点，则值为null，不是父节点则为其父节点ID
        /// </summary>
        public string parent { get; set; }
        /// <summary>
        /// 表示是否加载完成，设置为True表示加载完成，不需要在加载
        /// </summary>
        public bool laoded { get; set; }
        /// <summary>
        /// 表示此节点是否展开
        /// </summary>
        public bool expanded { get; set; }
    }
}
