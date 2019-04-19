namespace ecoMonedasMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DetalleCanjes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? Cantidad { get; set; }

        public double? Monto { get; set; }

        public int? Canje_id { get; set; }

        public int? Material_id { get; set; }

        public virtual Canjes Canjes { get; set; }

        public virtual Material Material { get; set; }
    }
}
