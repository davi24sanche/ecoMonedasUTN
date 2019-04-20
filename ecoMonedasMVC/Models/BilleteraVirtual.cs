namespace ecoMonedasMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BilleteraVirtual")]
    public partial class BilleteraVirtual
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public double TotalMonedasDisponibles { get; set; }

        public double TotalMonedasCanjeadas { get; set; }

        public double TotalMonedasGeneradas { get; set; }

        [Required]
        [StringLength(30)]
        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
