﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppGlovo.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbglovoEntities1 : DbContext
    {
        public dbglovoEntities1()
            : base("name=dbglovoEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categorias> categorias { get; set; }
        public virtual DbSet<detalle_pedidos> detalle_pedidos { get; set; }
        public virtual DbSet<establecimientos> establecimientos { get; set; }
        public virtual DbSet<eventos> eventos { get; set; }
        public virtual DbSet<horario> horario { get; set; }
        public virtual DbSet<Horario_establecimiento> Horario_establecimiento { get; set; }
        public virtual DbSet<pagos> pagos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<detalle_pago> detalle_pago { get; set; }
        public virtual DbSet<tarifas> tarifas { get; set; }
        public virtual DbSet<comisiones> comisiones { get; set; }
        public virtual DbSet<pedidos> pedidos { get; set; }
        public virtual DbSet<empresas> empresas { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<tarjetas> tarjetas { get; set; }
        public virtual DbSet<personas> personas { get; set; }
        public virtual DbSet<Horario_glover> Horario_glover { get; set; }
    }
}
