using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaPedidos.Models;

namespace SistemaPedidos.Data
{
    public class ServicoPopularizacao
    {
        private SistemaPedidosContext _contexto;

        public ServicoPopularizacao(SistemaPedidosContext contexto)
        {
            _contexto = contexto;
        }

        public void Popular()
        {
            if(_contexto.Pedido.Any() ||
                _contexto.Prato.Any() ||
                _contexto.Bebida.Any())
            {
                return;
            }

            Prato p1 = new Prato(1, "Macarronada");
            Prato p2 = new Prato(2, "Feijoada");
            Prato p3 = new Prato(3, "Frango a Passarinho");
            Prato p4 = new Prato(4, "Milanesa");
            Prato p5 = new Prato(5, "Salada");
            Prato p6 = new Prato(6, "Lasanha");
            Prato p7 = new Prato(7, "Vaca Atolada");
            Prato p8 = new Prato(8, "Buchada de Bode");
            Prato p9 = new Prato(9, "Tropeiro");
            Prato p10 = new Prato(10, "Nhoque");

            Bebida b1 = new Bebida("Coca-Cola", 1);
            Bebida b2 = new Bebida("Guaraná", 2);
            Bebida b3 = new Bebida("Fanta", 3);
            Bebida b4 = new Bebida("Água com gás", 4);
            Bebida b5 = new Bebida("Água Mineral", 5);

            _contexto.Prato.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            _contexto.Bebida.AddRange(b1, b2, b3, b4, b5);

            _contexto.SaveChanges();
        }
    }
}
