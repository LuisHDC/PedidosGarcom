using SistemaPedidos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaPedidos.Models;
using Microsoft.EntityFrameworkCore;
namespace SistemaPedidos.Services
{
    public class BebidaService
    {
        private readonly SistemaPedidosContext _contexto;

        public BebidaService(SistemaPedidosContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Bebida>> FindAllAsync()
        {
            return await _contexto.Bebida.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task InsertAsync(Bebida obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Bebida> FindByIDAsync(int id)
        {
            return await _contexto.Bebida.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _contexto.Bebida.FindAsync(id);
                _contexto.Bebida.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(Bebida obj)
        {
            bool hasAny = await _contexto.Bebida.AnyAsync(x => x.Id == obj.Id);
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
