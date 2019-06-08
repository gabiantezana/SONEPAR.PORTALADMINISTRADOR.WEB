using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SONEPAR.PORTALADMINISTRADOR.WEB.HELPER;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.Administracion.Rol
{
    public class RolViewModel
    {
        public RolViewModel()
        {
          
        }

        public int? RolId { get; set; }

        [Required(ErrorMessage="Campo requerido")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Descripcion { get; set; }

        [Required]
        public int? Nivel { get; set; }
        public List<JsonEntity> NivelJList { get; set; }
    }
}
