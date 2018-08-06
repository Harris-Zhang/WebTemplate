using BZ.Common;
using BZ.DbHelper.DataProvider;
using BZ.Domain.admin; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Repository.admin
{
    public class SysLanguageRep : BaseRep 
    {
        public int Insert(SysLanguageModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO SYSLANGUAGE");
            sql.Append("  (LANGID,");
            sql.Append("   CONTROLID,");
            sql.Append("   CONTROLTYPE,");
            sql.Append("   PAGEID,");
            sql.Append("   DIALOGID,");
            sql.Append("   ZH_CN,");
            sql.Append("   ZH_TW,");
            sql.Append("   EN_US,");
            sql.Append("   DE_DE,");
            sql.Append("   KO_KR,");
            sql.Append("   JA_JP,");
            sql.Append("   FR_FR,");
            sql.Append("   RU_RU,");
            sql.Append("   CREATEUSER)");
            sql.Append("VALUES");
            sql.Append("  ($LANGID,");
            sql.Append("   $CONTROLID,");
            sql.Append("   $CONTROLTYPE,");
            sql.Append("   $PAGEID,");
            sql.Append("   $DIALOGID,");
            sql.Append("   $ZH_CN,");
            sql.Append("   $ZH_TW,");
            sql.Append("   $EN_US,");
            sql.Append("   $DE_DE,");
            sql.Append("   $KO_KR,");
            sql.Append("   $JA_JP,");
            sql.Append("   $FR_FR,");
            sql.Append("   $RU_RU,");
            sql.Append("   $CREATEUSER)");
            sql.Append("");

            SQLParameter[] parms ={
                                     new SQLParameter("LANGID",typeof(string),model.LANGID),
                                     new SQLParameter("CONTROLID",typeof(string),model.CONTROLID),
                                     new SQLParameter("CONTROLTYPE",typeof(string),model.CONTROLTYPE),
                                     new SQLParameter("PAGEID",typeof(string),model.PAGEID),
                                     new SQLParameter("DIALOGID",typeof(string),model.DIALOGID),
                                     new SQLParameter("ZH_CN",typeof(string),model.ZH_CN),
                                     new SQLParameter("ZH_TW",typeof(string),model.ZH_TW),
                                     new SQLParameter("EN_US",typeof(string),model.EN_US),
                                     new SQLParameter("DE_DE",typeof(string),model.DE_DE),
                                     new SQLParameter("KO_KR",typeof(string),model.KO_KR),
                                     new SQLParameter("JA_JP",typeof(string),model.JA_JP),
                                     new SQLParameter("FR_FR",typeof(string),model.FR_FR),
                                     new SQLParameter("RU_RU",typeof(string),model.RU_RU),
                                     new SQLParameter("CREATEUSER",typeof(string),model.CREATEUSER)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
            
        }

        public int Delete(string langId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE FROM SYSLANGUAGE WHERE LANGID = $LANGID");
            SQLParameter[] parms ={
                                     new SQLParameter("LANGID",typeof(string),langId)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }

        public int Edit(SysLanguageModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE SYSLANGUAGE");
            sql.Append("   SET CONTROLID  = $CONTROLID,");
            sql.Append("       CONTROLTYPE= $CONTROLTYPE,");
            sql.Append("       PAGEID     = $PAGEID,");
            sql.Append("       DIALOGID   = $DIALOGID,");
            sql.Append("       ZH_CN      = $ZH_CN,");
            sql.Append("       ZH_TW      = $ZH_TW,");
            sql.Append("       EN_US      = $EN_US,");
            sql.Append("       DE_DE      = $DE_DE,");
            sql.Append("       KO_KR      = $KO_KR,");
            sql.Append("       JA_JP      = $JA_JP,");
            sql.Append("       FR_FR      = $FR_FR,");
            sql.Append("       RU_RU      = $RU_RU");
            sql.Append(" WHERE LANGID = $LANGID");

            SQLParameter[] parms ={
                                     new SQLParameter("CONTROLID",typeof(string),model.CONTROLID),
                                     new SQLParameter("CONTROLTYPE",typeof(string),model.CONTROLTYPE),
                                     new SQLParameter("PAGEID",typeof(string),model.PAGEID),
                                     new SQLParameter("DIALOGID",typeof(string),model.DIALOGID),
                                     new SQLParameter("ZH_CN",typeof(string),model.ZH_CN),
                                     new SQLParameter("ZH_TW",typeof(string),model.ZH_TW),
                                     new SQLParameter("EN_US",typeof(string),model.EN_US),
                                     new SQLParameter("DE_DE",typeof(string),model.DE_DE),
                                     new SQLParameter("KO_KR",typeof(string),model.KO_KR),
                                     new SQLParameter("JA_JP",typeof(string),model.JA_JP),
                                     new SQLParameter("FR_FR",typeof(string),model.FR_FR),
                                     new SQLParameter("RU_RU",typeof(string),model.RU_RU),
                                     new SQLParameter("LANGID",typeof(string),model.LANGID),
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }

        public DataTable GetList(GridPager pager,string pageId,string dialogId,string langValue)
        {
            List<SQLParameter> list = new List<SQLParameter>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT LANGID,");
            sql.Append("       CONTROLID,");
            sql.Append("       CONTROLTYPE,");
            sql.Append("       PAGEID,");
            sql.Append("       DIALOGID,");
            sql.Append("       ZH_CN,");
            sql.Append("       ZH_TW,");
            sql.Append("       EN_US,");
            sql.Append("       DE_DE,");
            sql.Append("       KO_KR,");
            sql.Append("       JA_JP,");
            sql.Append("       FR_FR,");
            sql.Append("       RU_RU");
            sql.Append("  FROM SYSLANGUAGE");
            sql.Append(" WHERE 1=1 ");
            if(!string.IsNullOrEmpty(pageId)){
                sql.Append(" AND PAGEID = $PAGEID");
                list.Add(new SQLParameter("PAGEID",typeof(string),pageId));
            }
            if(!string.IsNullOrEmpty(dialogId)){
                sql.Append(" AND DIALOGID = $DIALOGID");
                list.Add(new SQLParameter("DIALOGID",typeof(string),dialogId));
            }
            if(!string.IsNullOrEmpty(langValue)){
                sql.Append(" AND (ZH_CN LIKE $LANGVALUE OR ZH_TW LIKE $LANGVALUE");
                sql.Append(" OR EN_US LIKE $LANGVALUE OR DE_DE LIKE $LANGVALUE");
                sql.Append(" OR KO_KR LIKE $LANGVALUE OR JA_JP LIKE $LANGVALUE ");
                sql.Append(" OR JA_JP LIKE $LANGVALUE OR FR_FR LIKE $LANGVALUE ");
                sql.Append(" OR RU_RU LIKE $LANGVALUE )");
                list.Add(new SQLParameter("LANGVALUE",typeof(string), StringHelper.GetSqlLike(pageId)));
            }

            SQLParameter[] parms = list.ToArray();
            pager.totalRows = DB.GetCount(new SQLParamCondition(string.Format("SELECT COUNT(*) COUNT FROM ({0}) TMP", sql), parms));

            DataSet ds = DB.CustomDataSet(new PagerParamCondition(sql.ToString(), pager.sortOrder, pager.startIndex, pager.endIndex, parms, false));
            return ds.Tables[0];

        }

        public DataTable GetById(string langId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT LANGID,");
            sql.Append("       CONTROLID,");
            sql.Append("       CONTROLTYPE,");
            sql.Append("       PAGEID,");
            sql.Append("       DIALOGID,");
            sql.Append("       ZH_CN,");
            sql.Append("       ZH_TW,");
            sql.Append("       EN_US,");
            sql.Append("       DE_DE,");
            sql.Append("       KO_KR,");
            sql.Append("       JA_JP,");
            sql.Append("       FR_FR,");
            sql.Append("       RU_RU");
            sql.Append("  FROM SYSLANGUAGE");
            sql.Append(" WHERE LANGID = $LANGID");
            SQLParameter[] parms ={
                                     new SQLParameter("LANGID",typeof(string),langId)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }

        public DataTable GetById(string pageId, string dialogId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT LANGID,");
            sql.Append("       CONTROLID,");
            sql.Append("       CONTROLTYPE,");
            sql.Append("       PAGEID,");
            sql.Append("       DIALOGID,");
            sql.Append("       ZH_CN,");
            sql.Append("       ZH_TW,");
            sql.Append("       EN_US,");
            sql.Append("       DE_DE,");
            sql.Append("       KO_KR,");
            sql.Append("       JA_JP,");
            sql.Append("       FR_FR,");
            sql.Append("       RU_RU");
            sql.Append("  FROM SYSLANGUAGE");
            sql.Append(" WHERE (PAGEID='all' AND DIALOGID='all')");
            sql.Append("   OR  (PAGEID = $PAGEID");
            sql.Append("   AND DIALOGID = $DIALOGID)");
            SQLParameter[] parms ={
                                     new SQLParameter("PAGEID",typeof(string),pageId),
                                     new SQLParameter("DIALOGID",typeof(string),dialogId)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }

        public DataTable GetByEasyUIAll()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT LANGID,");
            sql.Append("       CONTROLID,");
            sql.Append("       CONTROLTYPE,");
            sql.Append("       PAGEID,");
            sql.Append("       DIALOGID,");
            sql.Append("       ZH_CN,");
            sql.Append("       ZH_TW,");
            sql.Append("       EN_US,");
            sql.Append("       DE_DE,");
            sql.Append("       KO_KR,");
            sql.Append("       JA_JP,");
            sql.Append("       FR_FR,");
            sql.Append("       RU_RU");
            sql.Append("  FROM SYSLANGUAGE");
            sql.Append(" WHERE PAGEID = 'EasyUI_All'");
            sql.Append("   AND DIALOGID = 'EasyUI_All'");
            DataSet ds = DB.CustomDataSet(new SQLCondition(sql.ToString()));
            return ds.Tables[0];
        }

        public DataTable GetByServerSystem(string controlId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT LANGID,");
            sql.Append("       CONTROLID,");
            sql.Append("       CONTROLTYPE,");
            sql.Append("       PAGEID,");
            sql.Append("       DIALOGID,");
            sql.Append("       ZH_CN,");
            sql.Append("       ZH_TW,");
            sql.Append("       EN_US,");
            sql.Append("       DE_DE,");
            sql.Append("       KO_KR,");
            sql.Append("       JA_JP,");
            sql.Append("       FR_FR,");
            sql.Append("       RU_RU");
            sql.Append("  FROM SYSLANGUAGE");
            sql.Append(" WHERE PAGEID='ServerSystem'  ");
            sql.Append("   AND DIALOGID='ServerSystem'");
            sql.Append("   AND CONTROLID = $CONTROLID");
            SQLParameter[] parms ={
                                     new SQLParameter("CONTROLID",typeof(string),controlId)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
    }
}


 
 
 
 
 
 
 
 
 
 















