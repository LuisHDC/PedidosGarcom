using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Data;
using SistemaPedidos.Models;
using SistemaPedidos.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidos.Services
{
    public class PedidoService
    {
        private readonly SistemaPedidosContext _context;

        public PedidoService(SistemaPedidosContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> FindAllAsync()
        {
            return await _context.Pedido.Include(c => c.Prato).Include(c => c.Bebida).OrderBy(x => x.Id).ToListAsync();
        }

        public async Task InsertAsync(Pedido obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Pedido> FindByIDAsync(int id)
        {
            return await _context.Pedido.Include(obj => obj.Bebida).Include(obj => obj.Prato).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Pedido.FindAsync(id);
                _context.Pedido.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(Pedido obj)
        {
            bool hasAny = await _context.Pedido.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new Exception("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

