//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SONEPAR.PORTALADMINISTRADOR.WEB.MODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.UsuarioRoles = new HashSet<UsuarioRoles>();
            this.UsuarioRoles1 = new HashSet<UsuarioRoles>();
        }
    
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Office365Mail { get; set; }
        public string SapUsername { get; set; }
        public Nullable<int> RolId { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Rol Rol { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioRoles> UsuarioRoles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioRoles> UsuarioRoles1 { get; set; }
    }
}