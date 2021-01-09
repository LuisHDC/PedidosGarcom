using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Data;
using SistemaPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidos.Services
{
    public class PedidoService
    {
        private readonly SistemaPedidosContext _contexto;

        public PedidoService(SistemaPedidosContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Pedido>> FindAllAsync()
        {
            return await _contexto.Pedido.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task InsertAsync(Pedido obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Pedido> FindByIDAsync(int id)
        {
            return await _contexto.Pedido.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _contexto.Pedido.FindAsync(id);
                _contexto.Pedido.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(Pedido obj)
        {
            bool hasAny = await _contexto.Pedido.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new Exception("Id not found");
            }
            try
            {
                _contexto.Update(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

