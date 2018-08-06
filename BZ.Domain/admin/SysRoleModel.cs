using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{
    /// <summary>
    //角色管理
    /// </summary>	
    [Serializable]
    public class SysRoleModel
    {
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>		
        public string ROLE_ID { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>		
        public string ROLE_NAME { get; set; }
        /// <summary>
        /// 角色说明
        /// </summary>		
        public string ROLE_DESC { get; set; }
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
