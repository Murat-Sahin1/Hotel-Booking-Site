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
    
    public partial class Tbl_Odeme
    {
        public int OdemeID { get; set; }
        public Nullable<int> OdaID { get; set; }
        public string OdemeFiyat { get; set; }
        public string OdemeTip { get; set; }
    
        public virtual Tbl_Oda Tbl_Oda { get; set; }
    }
}
