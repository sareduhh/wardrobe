﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wardrobe.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class wardrobeEntities : DbContext
    {
        public wardrobeEntities()
            : base("name=wardrobeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<Bottom> Bottoms { get; set; }
        public virtual DbSet<Shoe> Shoes { get; set; }
        public virtual DbSet<Top> Tops { get; set; }
        public virtual DbSet<Wardrobe> Wardrobes { get; set; }
    }
}
