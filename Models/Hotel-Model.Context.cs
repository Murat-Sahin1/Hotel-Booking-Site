﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class My_HotelEntities : DbContext
    {
        public My_HotelEntities()
            : base("name=My_HotelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Oda> Tbl_Oda { get; set; }
        public virtual DbSet<Tbl_Odeme> Tbl_Odeme { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<Tbl_Otopark> Tbl_Otopark { get; set; }
        public virtual DbSet<Tbl_Calisan> Tbl_Calisan { get; set; }
    }
}
