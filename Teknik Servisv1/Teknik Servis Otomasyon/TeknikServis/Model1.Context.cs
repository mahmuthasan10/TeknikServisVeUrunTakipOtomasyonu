﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikServis
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBTEKNIKSERVISEntities : DbContext
    {
        public DBTEKNIKSERVISEntities()
            : base("name=DBTEKNIKSERVISEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TBLADMIN> TBLADMINs { get; set; }
        public virtual DbSet<TBLKATEGORI> TBLKATEGORIs { get; set; }
        public virtual DbSet<TBLMUSTERI> TBLMUSTERIs { get; set; }
        public virtual DbSet<TBLPERSONEL> TBLPERSONELs { get; set; }
        public virtual DbSet<TBLURUN> TBLURUNs { get; set; }
        public virtual DbSet<TBLIL> TBLILs { get; set; }
        public virtual DbSet<TBLURUNSATIS> TBLURUNSATISs { get; set; }
        public virtual DbSet<TBLURUNARIZA> TBLURUNARIZAs { get; set; }
    }
}
