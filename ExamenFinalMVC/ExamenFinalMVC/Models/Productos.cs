using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinalMVC.Models
{
    public class Productos
    {
        public Productos()
        {
            DetalleFactura = new List<DetalleFactura>();
        }
        [Key]
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int NivelNuevoPedido { get; set; }
        public bool Suspendido { get; set; }



        [ForeignKey("IdProveedor")]
        public virtual Proveedores Proveedores { get; set; }
        [ForeignKey("IdCategoria")]
        public virtual Categorias Categorias { get; set; }
        public virtual List<DetalleFactura> DetalleFactura { get; set; }
    }
}
