using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaPedidos.Data;
using SistemaPedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaPedidos.Services
{
    public class PedidosService
    {
        private readonly SistemaPedidosContext _context;

        public async Task InsertAsync(Pedido obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
