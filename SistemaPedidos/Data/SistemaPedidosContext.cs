using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Models;

namespace SistemaPedidos.Data
{
    public class SistemaPedidosContext : DbContext
    {
        public SistemaPedidosContext (DbContextOptions<SistemaPedidosContext> options)
            : base(options)
        {
        }

        public DbSet<Pedido> pedido { get; set; }
        public DbSet<Prato> prato { get; set; }
        public DbSet<Bebida> Bebida { get; set; }
    }
}
