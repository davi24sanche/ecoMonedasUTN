namespace ecoMonedasMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Canjes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Canjes()
        {
            DetalleCanjes = new HashSet<DetalleCanjes>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string UsuarioId { get; set; }

        public int CentroAcopioId { get; set; }

        public int Cantidad { get; set; }

        public int MaterialId { get; set; }

        [Required]
        [StringLength(30)]
        public string ClienteId { get; set; }

        [Required]
        [StringLength(50)]
        public string Fecha { get; set; }

        public virtual CentroAcopio CentroAcopio { get; set; }

        public virtual Material Material { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCanjes> DetalleCanjes { get; set; }
    }
}
