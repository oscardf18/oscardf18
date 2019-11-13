using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinalMVC.Models
{
    public class Clientes
    {


            public Clientes()
            {
                DetalleFactura = new List<DetalleFactura>();
            }
            [Key]
            public int IdCliente { get; set; }
            public string NombreCliente { get; set; }
            public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
            public string Telefono { get; set; }

            public virtual List<DetalleFactura> DetalleFactura { get; set; }
        }
    }

