using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinalMVC.Models
{
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }
        public string Empresa { get; set; }
        public string NombreContrato { get; set; }
        public string TelefonoProveedor { get; set; }
        public string Correo { get; set; }
        public string SitioWeb { get; set; }
        public virtual List<Productos> Productos { get; set; }

        public Proveedores()
        {
            Productos = new List<Productos>();
        }
    }
}
