namespace ecoMonedasMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EcoContext : DbContext
    {
        public EcoContext()
            : base("name=EcoContext")
        {
        }

        public virtual DbSet<BilleteraVirtual> BilleteraVirtual { get; set; }
        public virtual DbSet<Canjes> Canjes { get; set; }
        public virtual DbSet<CentroAcopio> CentroAcopio { get; set; }
        public virtual DbSet<Colores> Colores { get; set; }
        public virtual DbSet<Cupon> Cupon { get; set; }
        public virtual DbSet<CuponCliente> CuponCliente { get; set; }
        public virtual DbSet<DetalleCanjes> DetalleCanjes { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Canjes>()
                .HasMany(e => e.DetalleCanjes)
                .WithOptional(e => e.Canjes)
                .HasForeignKey(e => e.Canje_id);

            modelBuilder.Entity<CentroAcopio>()
                .HasMany(e => e.Canjes)
                .WithRequired(e => e.CentroAcopio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Colores>()
                .HasMany(e => e.Material)
                .WithOptional(e => e.Colores)
                .HasForeignKey(e => e.colorId);

            modelBuilder.Entity<Cupon>()
                .HasMany(e => e.CuponCliente)
                .WithRequired(e => e.Cupon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Canjes)
                .WithRequired(e => e.Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.DetalleCanjes)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.Material_id);

            modelBuilder.Entity<Provincias>()
                .HasMany(e => e.CentroAcopio)
                .WithRequired(e => e.Provincias)
                .HasForeignKey(e => e.ProvinciaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Rol1)
                .HasForeignKey(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.BilleteraVirtual)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Canjes)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.ClienteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.CentroAcopio)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.CuponCliente)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .WillCascadeOnDelete(false);
        }
    }
}
