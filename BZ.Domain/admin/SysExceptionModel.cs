using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{
    /// <summary>
    //系统异常信息
    /// </summary>	
    [Serializable]
    public class SysExceptionModel
    {

        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 异常ID
        /// </summary>		
        public string EX_ID { get; set; }
        /// <summary>
        /// 异常帮助连接
        /// </summary>		
        public string EX_HELPLINK { get; set; }
        /// <summary>
        /// 异常信息
        /// </summary>		
        public string EX_MESSAGE { get; set; }
        /// <summary>
        /// 异常来源
        /// </summary>		
        public string EX_SOURCE { get; set; }
        /// <summary>
        /// 堆栈
        /// </summary>		
        public string EX_STACK { get; set; }
        /// <summary>
        /// 项目页
        /// </summary>		
        public string EX_TARGET { get; set; }
        /// <summary>
        /// 程序集
        /// </summary>		
        public string EX_DATA { get; set; }
        /// <summary>
        /// 命名空间
        /// </summary>		
        public string EX_NAMESPACE { get; set; }
        /// <summary>
        /// 类名
        /// </summary>		
        public string EX_CLASS { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>		
        public string EX_METHOD { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>		
        public string EX_TYPE { get; set; }
        /// <summary>
        /// 说明
        /// </summary>		
        public string EX_DESC { get; set; }
        /// <summary>
        /// 创建人员
        /// </summary>		
        public string CREATE_USER { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>		
        public DateTime LM_TIME { get; set; }
        /// <summary>
        /// 修改人员
        /// </summary>		
        public string LM_USER { get; set; }

    }
}
