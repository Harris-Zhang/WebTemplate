using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{
    /// <summary>
    //用户角色信息
    /// </summary>	
    [Serializable]
    public class SysUserRoleModel
    {
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>		
        public string USER_CODE { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>		
        public string ROLE_ID { get; set; }
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
