
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{
    [Serializable]
    /// <summary>
    //SYS_USER
    /// </summary>	
    public class SysUserModel
    {
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 用户代码
        /// </summary>		
        public string USER_CODE { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>		
        public string USER_NAME { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>		
        public int USER_SEX { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>		
        public string USER_PWD { get; set; }
        /// <summary>
        /// 用户职位
        /// </summary>		
        public string USER_POST { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>		
        public string USER_EMAIL { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>		
        public string USER_TEL { get; set; }
        /// <summary>
        /// 用户说明
        /// </summary>
        public string USER_DESC { get; set; }
        /// <summary>
        /// 用户二维码
        /// </summary>		
        public string QR_CODE { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>		
        public int IS_ABLED { get; set; }
        /// <summary>
        /// 是否改密
        /// </summary>		
        public int IS_C_PWD { get; set; }
        /// <summary>
        /// 部门代码
        /// </summary>		
        public string DEPT_CODE { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>		
        public string DEPT_NAME { get; set; }
        /// <summary>
        /// 用户上级代码
        /// </summary>		
        public string BOSS_ID { get; set; }
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
