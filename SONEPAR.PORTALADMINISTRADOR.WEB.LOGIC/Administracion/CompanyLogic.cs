using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using SONEPAR.WEB.DATAACCESS.Administracion;
using SONEPAR.WEB.DATAACCESS.GestionDocumentos;
using SONEPAR.WEB.HELPER;
using SONEPAR.WEB.MODEL;
using SONEPAR.WEB.VIEWMODEL.Administracion.Area;
using SONEPAR.WEB.VIEWMODEL.GestionDocumentos;

namespace SONEPAR.WEB.LOGIC.Administracion
{
    public static class CompanyLogic
    {
        #region GetList

        private static IEnumerable<Company> GetQuery(DataContext dataContext, string filter = null)
        {
            return new CompanyDataAccess(dataContext).GetList(filter);
        }

        public static IEnumerable<JsonEntity> GetJList(DataContext dataContext, string filter)
        {
            var query = GetQuery(dataContext, filter);
            var jsonEntities = query?.Select(x => new JsonEntity()
            {
                id = x.CompanyId,
                text = x.DbName,
            });
            return jsonEntities;
        }

        #endregion
    }
}
