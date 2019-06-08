using SONEPAR.PORTALADMINISTRADOR.WEB.HELPER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SONEPAR.PORTALADMINISTRADOR.WEB.MODEL;
using SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.Administracion.Rol;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.VIEWMODEL.Administracion.Usuario
{
    public class UsuarioViewModel
    {
        public int? UsuarioId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Office365Mail { get; set; }
        public string SapUsername { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public int RolId { get; set; }
        public List<JsonEntity> RolJList { get; set; } = new List<JsonEntity>();

        [Required]
        public bool IsActive { get; set; }


        #region Roles por Usuario

        /// <summary>
        /// Listado de todos los roles que existen en la base de datos.
        /// </summary>
        public IEnumerable<MODEL.Rol> RolList { get; set; } = new List<MODEL.Rol>();

        /// <summary>
        /// Listado de roles asociados al usuario.
        /// </summary>
        public IEnumerable<UsuarioRoles> RolUserList { get; set; } =  new List<UsuarioRoles>();

        #endregion


    }
}
