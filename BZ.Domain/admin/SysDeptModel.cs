using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{ 
    [Serializable]
    /// <summary>
    //部门信息表
    /// </summary>	
    public class SysDeptModel
    { 
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 部门代码
        /// </summary>		
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>		
        public string DEPT_NAME { get; set; }
        /// <summary>
        /// 父级部门
        /// </summary>		
        public string PARENT_CODE { get; set; }
        /// <summary>
        /// 厂区编号
        /// </summary>		
        public string SITE_CODE { get; set; }
        /// <summary>
        /// 厂区名称
        /// </summary>		
        public string SITE_NAME { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>		
        public int DEPT_SORT { get; set; }
        /// <summary>
        /// 类别
        /// </summary>		
        public string DEPT_TYPE { get; set; }
        /// <summary>
        /// 说明
        /// </summary>		
        public string DEPT_DESC { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>		
        public int IS_ABLE { get; set; }
        /// <summary>
        /// 是否最后一项
        /// </summary>		
        public int IS_END { get; set; }

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

        public string state { get; set; }

    }
}
