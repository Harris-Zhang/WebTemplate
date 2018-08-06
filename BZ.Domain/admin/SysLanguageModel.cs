using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{
    public class SysLanguageModel
    {
        /// <summary>
        /// 多语言ID
        /// </summary>
        public string LANGID { get; set; }
        /// <summary>
        /// 控件ID
        /// </summary>
        public string CONTROLID { get; set; }
        /// <summary>
        /// 控件类别
        /// </summary>
        public string CONTROLTYPE { get; set; }
        /// <summary>
        /// 页面ID
        /// </summary>
        public string PAGEID { get; set; }
        /// <summary>
        /// 弹出框ID
        /// </summary>
        public string DIALOGID { get; set; }
        /// <summary>
        /// 简体中文
        /// </summary>
        public string ZH_CN { get; set; }
        /// <summary>
        /// 繁体中文
        /// </summary>
        public string ZH_TW { get; set; }
        /// <summary>
        /// 英文
        /// </summary>
        public string EN_US { get; set; }
        /// <summary>
        /// 德文
        /// </summary>
        public string DE_DE { get; set; }
        /// <summary>
        /// 韩文
        /// </summary>
        public string KO_KR { get; set; }
        /// <summary>
        /// 日文
        /// </summary>
        public string JA_JP { get; set; }
        /// <summary>
        /// 发文
        /// </summary>
        public string FR_FR { get; set; }
        /// <summary>
        /// 俄文
        /// </summary>
        public string RU_RU { get; set; }
        /// <summary>
        /// 创建人员
        /// </summary>
        public string CREATEUSER { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CREATEDATE { get; set; }

        /// <summary>
        /// 需要返回的值
        /// </summary>
        public string langValue { get; set; }
    }
}
