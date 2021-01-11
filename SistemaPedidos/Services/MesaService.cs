using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Data;
using SistemaPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidos.Services
{
    public class MesaService
    {
        private readonly SistemaPedidosContext _context;

        public MesaService(SistemaPedidosContext context)
        {
            _context = context;
        }

        public List<Pedido> FindPedidosByIDAsync(int id)
        {
            return _context.Pedido.Include(obj => obj.Prato).Include(obj => obj.Bebida).Include(obj => obj.Mesa).Where(obj => obj.MesaId == id).ToList();
        }
    }
}
