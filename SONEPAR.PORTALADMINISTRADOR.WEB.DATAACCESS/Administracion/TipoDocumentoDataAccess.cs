using System.Collections.Generic;
using SONEPAR.WEB.MODEL;
using SONEPAR.WEB.VIEWMODEL.Administracion.NivelAprobacion;

namespace SONEPAR.WEB.DATAACCESS.Administracion
{
    public class TipoDocumentoDataAccess
    {
        private DataContext DataContext { get; set; }

        public TipoDocumentoDataAccess(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IEnumerable<TipoDocumento> GetList()
        {
            return null;
            //return DataContext.Context.TipoDocumento;
        }
    }
}
