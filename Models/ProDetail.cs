//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DO_AN_FPT_SHOP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProDetail()
        {
            this.ColorProDes = new HashSet<ColorProDe>();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.StoProDes = new HashSet<StoProDe>();
        }
    
        public int SupID { get; set; }
        public int ProID { get; set; }
        public int ProDeID { get; set; }
        public string Function { get; set; }
        public Nullable<int> Pin { get; set; }
        public Nullable<int> Monitor { get; set; }
        public string Camera { get; set; }
        public string Chip { get; set; }
        public Nullable<int> Ram { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ColorProDe> ColorProDes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoProDe> StoProDes { get; set; }
    }
}
