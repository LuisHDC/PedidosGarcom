using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidos.Models.ViewModels
{
    public class PedidosViewModel
    {
        public Pedido Pedido { get; set; }
        public ICollection<Prato> Pratos { get; set; }
        public ICollection<Bebida> Bebidas { get; set; }
    }
}
