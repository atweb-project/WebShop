//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebShop.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrOrder : EntityBase
    {
        public int IdTrOrder { get; set; }
        public int IdOrder { get; set; }
        public int IdItem { get; set; }
        public Nullable<decimal> ItemKg { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}