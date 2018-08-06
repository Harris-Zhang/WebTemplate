using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{
    /// <summary>
    //角色页面权限
    /// </summary>	
    [Serializable]
    public class SysRightModel
    {

        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>		
        public string RIGHTID { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>		
        public string MENUID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>		
        public string ROLEID { get; set; }
        /// <summary>
        /// 权限标记
        /// </summary>		
        public int RIGHTFLAG { get; set; }
        /// <summary>
        /// 创建人员
        /// </summary>		
        public string CREATE_USER { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>		
        public DateTime LM_TIME { get; set; }
        /// <summary>
        /// 最后修改人员
        /// </summary>		
        public string LM_USER { get; set; }        
    }
}
