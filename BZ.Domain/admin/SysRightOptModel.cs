using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{
    /// <summary>
    /// 角色页面权限操作信息
    /// </summary>
    [Serializable]
    public class SysRightOptModel
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
        /// 角色ID
        /// </summary>		
        public string ROLE_ID { get; set; }
        /// <summary>
        /// 操作码代码
        /// </summary>		
        public string MO_CODE { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>		
        public int IS_ABLED { get; set; }
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
    }
}
