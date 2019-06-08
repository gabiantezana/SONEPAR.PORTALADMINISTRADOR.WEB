using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.MODEL
{
    public class DataContext
    {
        public HttpSessionStateBase Session { get; set; }
        public DB_SAPAUTHORIZATIONEntities Context { get; set; }
        public String CurrentCulture { get; set; }
        public String SystemNameSpace { get; set; }
        public HttpBrowserCapabilitiesBase Browser { get; set; }
        //public Company Company { get; set; }
    }

    public enum SapDbServerType
    {
        Sql,
        Hana,
    }
}
