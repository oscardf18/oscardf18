using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinalMVC.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFactura = new List<DetalleFactura>();
        }

        [Key]
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
       
        public virtual Clientes Clientes { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual List<DetalleFactura> DetalleFactura { get; set; }

    }
   
}
