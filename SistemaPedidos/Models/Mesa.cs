using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidos.Models
{
    public class Mesa
    {
        public ICollection<Pedido> Pedidos { get; set; }
        public int Id { get; set; }

        public Mesa()
        {

        }

        public Mesa(int id)
        {
            Id = id;
        }

        public void AdicionarPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }
    }
}
