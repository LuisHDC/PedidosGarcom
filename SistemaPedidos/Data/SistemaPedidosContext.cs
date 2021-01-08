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

        public DbSet<SistemaPedidos.Models.Pedido> Pedido { get; set; }
    }
}
