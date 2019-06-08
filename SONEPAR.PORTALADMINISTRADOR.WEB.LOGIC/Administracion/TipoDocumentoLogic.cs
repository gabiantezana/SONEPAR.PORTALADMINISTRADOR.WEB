using System.Collections.Generic;
using System.Linq;
using PagedList;
using SONEPAR.WEB.DATAACCESS.Administracion;
using SONEPAR.WEB.HELPER;
using SONEPAR.WEB.MODEL;
using SONEPAR.WEB.VIEWMODEL.Administracion.NivelAprobacion;

namespace SONEPAR.WEB.LOGIC.Administracion
{
    public static class TipoDocumentoLogic
    {
        private static IEnumerable<TipoDocumento> GetQueryList(DataContext dataContext, string filtro = null)
        {
            return new TipoDocumentoDataAccess(dataContext).GetList();
        }

        public static IEnumerable<JsonEntity> GetJList(DataContext dataContext)
        {
            var query = GetQueryList(dataContext);
            var jsonEntities = query?.Select(x => new JsonEntity()
            {
                id = x.TipoDocumentoId,
                text = x.Descripcion
            });

            return jsonEntities;
        }
    }
}
