using SistemaPedidos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaPedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaPedidos.Services
{
    public class PratoService
    {
        private readonly SistemaPedidosContext _contexto;

        public PratoService(SistemaPedidosContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Prato>> FindAllAsync()
        {
            return await _contexto.Prato.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task InsertAsync(Prato obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Prato> FindByIDAsync(int id)
        {
            return await _contexto.Prato.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _contexto.Prato.FindAsync(id);
                _contexto.Prato.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(Pedido obj)
        {
            bool hasAny = await _contexto.Prato.AnyAsync(x => x.Id == obj.Id);
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
