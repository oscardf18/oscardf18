using System;
using System.ComponentModel.DataAnnotations;

namespace ExamenFinalMVC.Models
{
    public partial class DetalleFactura
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Productos Productos { get; set; }
    }
}