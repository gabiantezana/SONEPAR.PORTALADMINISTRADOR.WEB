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
    
    public partial class SapUsersPerAprovalTypeLevel
    {
        public int SapUsersPerAprovalTypeLevelId { get; set; }
        public string sapUsername { get; set; }
        public Nullable<int> AprovalSubTypeId { get; set; }
        public Nullable<int> NumberOrder { get; set; }
    
        public virtual AprovalSubType AprovalSubType { get; set; }
    }
}
