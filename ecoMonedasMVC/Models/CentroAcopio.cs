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

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        
        public string Nombre { get; set; }

        public int ProvinciaId { get; set; }

        [Required]
        [Display(Name = "Dirección exacta")]
        public string DireccionExacta { get; set; }

        [Required]
        [StringLength(30)]
        public string UsuarioId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Canjes> Canjes { get; set; }

        public virtual Provincias Provincias { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
