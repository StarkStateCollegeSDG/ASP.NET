﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoroskoWebsite.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StarkStateEntities : DbContext
    {
        public StarkStateEntities()
            : base("name=StarkStateEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdvVB> AdvVBs { get; set; }
        public virtual DbSet<AdvCPP> AdvCPPs { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Final> Finals { get; set; }
    }
}
