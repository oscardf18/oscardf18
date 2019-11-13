using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinalMVC.Models
{
    public class Empleado
    {

        public Empleado()
        {
            DetalleFactura = new List<DetalleFactura>();
        }
        [Key]
        public int IdEmpleado{ get; set; }
        public string NombreEmpleado { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual List<DetalleFactura> DetalleFactura { get; set; }
    }
}