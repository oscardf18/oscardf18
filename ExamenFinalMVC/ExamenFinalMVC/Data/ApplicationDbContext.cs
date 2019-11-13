using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ExamenFinalMVC.Models;

namespace ExamenFinalMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ExamenFinalMVC.Models.Categorias> Categorias { get; set; }
        public DbSet<ExamenFinalMVC.Models.Clientes> Clientes { get; set; }
        public DbSet<ExamenFinalMVC.Models.Empleado> Empleado { get; set; }
        public DbSet<ExamenFinalMVC.Models.Productos> Productos { get; set; }
        public DbSet<ExamenFinalMVC.Models.Proveedores> Proveedores { get; set; }
        public DbSet<ExamenFinalMVC.Models.Factura> Factura { get; set; }
    }
}
