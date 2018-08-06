using BZ.Domain.admin; 
using BZ.Repository.admin;
using BZ.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.App.admin
{
    public class SysLanguageApp : BaseApp 
    {
        SysLanguageRep _languageRep = new SysLanguageRep();

        public IList<SysLanguageModel> GetById(string langType, string pageId, string dialogId)
        {
            DataTable dt = _languageRep.GetById(pageId, dialogId);

            //List<SysLanguageModel> list = dt.ToList<SysLanguageModel>();

            List<SysLanguageModel> list = new List<SysLanguageModel>();
            foreach (DataRow dr in dt.Rows)
            {
                SysLanguageModel model = new SysLanguageModel();
                model.CONTROLID = dr["CONTROLID"].ToString();
                model.CONTROLTYPE = dr["CONTROLTYPE"].ToString();
                model.langValue = dr[langType.ToUpper()].ToString();
                list.Add(model);
            }
            return list;
        }

        public IList<SysLanguageModel> GetByEasyUIAll(string langType)
        {
            DataTable dt = _languageRep.GetByEasyUIAll();

            //List<SysLanguageModel> list = dt.ToList<SysLanguageModel>();

            List<SysLanguageModel> list = new List<SysLanguageModel>();
            foreach (DataRow dr in dt.Rows)
            {
                SysLanguageModel model = new SysLanguageModel();
                model.CONTROLID = dr["CONTROLID"].ToString();
                model.langValue = dr[langType.ToUpper()].ToString();
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 返回页面的多语言提示信息
        /// </summary>
        /// <param name="langKey"></param>
        /// <returns></returns>
        public string GetServerSystem(string langKey)
        {
            string langValue = langKey;
            SysLanguageRep _langRep = new SysLanguageRep();
            DataTable dt = _langRep.GetByServerSystem(langKey);
            if (dt != null && dt.Rows.Count > 0)
            {
                langValue = dt.Rows[0][LangName.ToUpper()].ToString();
            }
            return langValue;
        }
    }
}
