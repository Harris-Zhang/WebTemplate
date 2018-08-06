using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{
    /// <summary>
    //系统操作日志
    /// </summary>	
    [Serializable]
    public class SysLogModel
    {
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 日志ID
        /// </summary>		
        public string LOG_ID { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>		
        public string OPERATE_ID { get; set; }
        /// <summary>
        /// 操作信息
        /// </summary>		
        public string LOG_MSG { get; set; }
        /// <summary>
        /// 操作结果
        /// </summary>		
        public string LOG_RESULT { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>		
        public string LOG_TYPE { get; set; }
        /// <summary>
        /// 操作模块
        /// </summary>		
        public string LOG_MODULE { get; set; }
        /// <summary>
        /// 说明
        /// </summary>		
        public string LOG_DESC { get; set; }
        /// <summary>
        /// 操作命名空间
        /// </summary>		
        public string LOG_NAMESPACE { get; set; }
        /// <summary>
        /// 操作类名
        /// </summary>		
        public string LOG_CLASS { get; set; }
        /// <summary>
        /// 操作方法
        /// </summary>		
        public string LOG_METHOD { get; set; }
        /// <summary>
        /// 日志Json标示
        /// </summary>
        public int JSON_TYPE { get; set; }
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
