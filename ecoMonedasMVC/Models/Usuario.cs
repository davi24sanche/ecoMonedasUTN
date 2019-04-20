namespace ecoMonedasMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            BilleteraVirtual = new HashSet<BilleteraVirtual>();
            Canjes = new HashSet<Canjes>();
            CentroAcopio = new HashSet<CentroAcopio>();
            CuponCliente = new HashSet<CuponCliente>();
        }

        [Key]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Usuario")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string Apellidos { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }

        public int Rol { get; set; }

        [Required]
        public string Contrasenna { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BilleteraVirtual> BilleteraVirtual { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Canjes> Canjes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CentroAcopio> CentroAcopio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CuponCliente> CuponCliente { get; set; }

        public virtual Rol Rol1 { get; set; }
    }
}
