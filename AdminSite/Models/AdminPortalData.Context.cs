﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminSite.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AdminPortalDataEntities2 : DbContext
    {
        public AdminPortalDataEntities2()
            : base("name=AdminPortalDataEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AssociateLink> AssociateLinks { get; set; }
        public virtual DbSet<AssociateRole> AssociateRoles { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}
