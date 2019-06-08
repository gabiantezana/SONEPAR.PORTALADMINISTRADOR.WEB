using System.Collections.Generic;
using PagedList;
using SONEPAR.PORTALADMINISTRADOR.WEB.HELPER;
using SONEPAR.PORTALADMINISTRADOR.WEB.MODEL;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.GestionDocumentos
{
    public class ListAuthorizationViewModel
    {
        public IPagedList<AuthorizationViewModel> PagedList { get; set; }
        public string Filter { get; set; }

        /// <summary>
        /// Solo para dar formato al select2 en la búsqueda predictiva
        /// </summary>
        public IEnumerable<AuthorizationViewModel> ListDefault { get; set; }
        public DocumentType DocumentType { get; set; }

    }
}
