namespace ecoMonedasMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CuponCliente")]
    public partial class CuponCliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string UsuarioId { get; set; }

        public int CuponId { get; set; }

        public virtual Cupon Cupon { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
