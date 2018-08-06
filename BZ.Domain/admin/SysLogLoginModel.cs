using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{
    /// <summary>
    //系统登录日志
    /// </summary>	
    [Serializable]
    public class SysLogLoginModel
    {
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime CREATE_TIME { get; set; } 

        /// <summary>
        /// ID
        /// </summary>
        public string LOGIN_ID { get; set; }

        /// <summary>
        /// 登录人员账号
        /// </summary>		
        public string USER_CODE { get; set; }
        /// <summary>
        /// 密码（密文）
        /// </summary>		
        public string USER_PWD { get; set; }
        /// <summary>
        /// 密码(明文)
        /// </summary>		
        public string USER_PWD_LAWS { get; set; }
        /// <summary>
        /// 登录ip
        /// </summary>		
        public string LOGIN_IP { get; set; }
        /// <summary>
        /// 登录结果
        /// </summary>		
        public string LOGIN_RESULT { get; set; }
        /// <summary>
        /// 结果说明
        /// </summary>		
        public string LOGIN_MSG { get; set; }
        /// <summary>
        /// 创建人员
        /// </summary>		
        public string CREATE_USER { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>		
        public DateTime LM_TIME { get; set; }
        /// <summary>
        /// 更新人员
        /// </summary>		
        public string LM_USER { get; set; }        
    }
}
