namespace ecoMonedasMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cupon")]
    public partial class Cupon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cupon()
        {
            CuponCliente = new HashSet<CuponCliente>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int? Cantidad { get; set; }

        public int? CantidadEcoMonedas { get; set; }

        [StringLength(50)]
        public string FechaInicio { get; set; }

        [StringLength(50)]
        public string FechaFin { get; set; }

        public int? ProductoId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CuponCliente> CuponCliente { get; set; }
    }
}
