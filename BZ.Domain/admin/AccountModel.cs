using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Domain.admin
{
    [Serializable]
    public class AccountModel
    {
        public string UserCode { get; set; }

        public string LoginNo { get; set; }

        public string UserName { get; set; } 

        public string QRCode { get; set; }

        public string Themes { get; set; }

        public string Language { get; set; }

        public string DeptCode { get; set; }

        public string ErpUserId { get; set; }
    }

    public class AppVersionModel
    {
        public DateTime CREATE_TIME { get; set; }

        public string VERSION_CODE { get; set; }

        public string VERSION_DESC { get; set; }

        public string APP_URL { get; set; }

        public string APP_NAME { get; set; }
    }
}
