namespace ecoMonedasMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CentroAcopio")]
    public partial class CentroAcopio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CentroAcopio()
        {
            Canjes = new HashSet<Canjes>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Centro de Acopio")]
        public string Nombre { get; set; }

        [Display(Name = "Provincia")]
        public int ProvinciaId { get; set; }

        [Required]
        [Display(Name = "Dirección Exacta")]
        public string DireccionExacta { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Usuario")]
        public string UsuarioId { get; set; }

        [Required]
        public int Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Canjes> Canjes { get; set; }

        public virtual Provincias Provincias { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
