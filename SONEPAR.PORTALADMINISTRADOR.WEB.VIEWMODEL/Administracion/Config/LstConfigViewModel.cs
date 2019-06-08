using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using SONEPAR.PORTALADMINISTRADOR.WEB.MODEL;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.Administracion.Config
{
  public  class LstConfigViewModel
    {
        public IPagedList<CONFIG> LstConfigs { get; set; }
        public String CampoBuscar { get; set; }
        public List<CONFIG> LstConfigsDefault { get; set; }
    }
}
