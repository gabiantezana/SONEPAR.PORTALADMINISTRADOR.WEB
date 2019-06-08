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
    
    public partial class AprovalSubType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AprovalSubType()
        {
            this.Authorizationn = new HashSet<Authorizationn>();
            this.AuthorizationnHistory = new HashSet<AuthorizationnHistory>();
            this.Authorizationn1 = new HashSet<Authorizationn>();
            this.AuthorizationnHistory1 = new HashSet<AuthorizationnHistory>();
            this.Authorizationn2 = new HashSet<Authorizationn>();
            this.AuthorizationnHistory2 = new HashSet<AuthorizationnHistory>();
            this.SapUsersPerAprovalTypeLevel = new HashSet<SapUsersPerAprovalTypeLevel>();
        }
    
        public int AprovalSubTypeId { get; set; }
        public Nullable<int> AprovalTypeId { get; set; }
        public string Name { get; set; }
        public Nullable<double> InitialRange { get; set; }
        public Nullable<double> FinalRange { get; set; }
        public Nullable<int> NumberOrder { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual AprovalType AprovalType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Authorizationn> Authorizationn { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuthorizationnHistory> AuthorizationnHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Authorizationn> Authorizationn1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuthorizationnHistory> AuthorizationnHistory1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Authorizationn> Authorizationn2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuthorizationnHistory> AuthorizationnHistory2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SapUsersPerAprovalTypeLevel> SapUsersPerAprovalTypeLevel { get; set; }
    }
}
