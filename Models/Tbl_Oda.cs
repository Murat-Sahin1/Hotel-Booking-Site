//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel_Booking_Site.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Oda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Oda()
        {
            this.Tbl_Odeme = new HashSet<Tbl_Odeme>();
        }
    
        public int OdaID { get; set; }
        public string OdaTip { get; set; }
        public string OdaKisiLimit { get; set; }
        public string OdaGenislik { get; set; }
        public string OdaDurum { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Odeme> Tbl_Odeme { get; set; }
        public virtual Tbl_Otopark Tbl_Otopark { get; set; }
    }
}
