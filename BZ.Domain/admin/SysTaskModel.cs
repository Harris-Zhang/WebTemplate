using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{
    /// <summary>
    //任务调度
    /// </summary>	
    [Serializable]
    public class SysTaskModel
    {
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 任务ID(系统生成guid)
        /// </summary>		
        public string TASK_ID { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>		
        public string TASK_NAME { get; set; }
        /// <summary>
        /// 任务执行参数
        /// </summary>		
        public string TASK_PARAM { get; set; }
        /// <summary>
        /// 任务所在组
        /// </summary>		
        public string TASK_GROUP { get; set; }
        /// <summary>
        /// cron表达式(触发时间)
        /// </summary>		
        public string CRON_EXPRESSION { get; set; }
        /// <summary>
        /// cron表达式(中文说明)
        /// </summary>		
        public string CRON_DESC { get; set; }
        /// <summary>
        /// 任务所在DLL对应的程序集名称
        /// </summary>		
        public string TASK_ASSEMBLY { get; set; }
        /// <summary>
        /// 任务所在类
        /// </summary>		
        public string TASK_CLASS { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>		
        public string TASK_STATUS { get; set; }
        /// <summary>
        /// 任务上次运行时间
        /// </summary>		
        public DateTime LAST_TIME { get; set; }
        /// <summary>
        /// 上次运行结果
        /// </summary>		
        public string LAST_RESULT { get; set; }
        /// <summary>
        /// 任务下次运行时间
        /// </summary>		
        public DateTime NEXT_TIME { get; set; }
        /// <summary>
        /// 任务说明
        /// </summary>		
        public string TASK_DESC { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>		
        public string IS_DELETE { get; set; }
        /// <summary>
        /// 是否验证,和状态做关联,判断使用
        /// </summary>		
        public string IS_VERIFY { get; set; }
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
