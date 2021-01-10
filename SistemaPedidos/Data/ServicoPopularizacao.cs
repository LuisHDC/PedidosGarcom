using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaPedidos.Models;

namespace SistemaPedidos.Data
{
    public class ServicoPopularizacao
    {
        private readonly SistemaPedidosContext _contexto;

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

            Prato p0 = new Prato(1, "Nada");
            Prato p1 = new Prato(2, "Macarronada");
            Prato p2 = new Prato(3, "Feijoada");
            Prato p3 = new Prato(4, "Frango a Passarinho");
            Prato p4 = new Prato(5, "Milanesa");
            Prato p5 = new Prato(6, "Salada");
            Prato p6 = new Prato(7, "Lasanha");
            Prato p7 = new Prato(8, "Vaca Atolada");
            Prato p8 = new Prato(9, "Buchada de Bode");
            Prato p9 = new Prato(10, "Tropeiro");
            Prato p10 = new Prato(11, "Nhoque");

            Bebida b0 = new Bebida(1, "Nada");
            Bebida b1 = new Bebida(2, "Coca-Cola");
            Bebida b2 = new Bebida(3, "Guaraná");
            Bebida b3 = new Bebida(4, "Fanta");
            Bebida b4 = new Bebida(5, "Água com gás");
            Bebida b5 = new Bebida(6, "Água Mineral");

            Pedido P1 = new Pedido(p1, b5, 3, "Paulo", 1, new DateTime(2020, 02, 15), Models.Enums.StatusPedido.Pendente);
            Pedido P2 = new Pedido(p5, b3, 4, "Sauro", 2, new DateTime(2020, 02, 15), Models.Enums.StatusPedido.VisualizadoPelaCozinha);
            Pedido P3 = new Pedido(p3, b2, 2, "Jennifer", 3, new DateTime(2020, 02, 15), Models.Enums.StatusPedido.PratoPronto);
            Pedido P4 = new Pedido(p7, b4, 8, "Luiza", 4, new DateTime(2020, 02, 15), Models.Enums.StatusPedido.Entregue);
            Pedido P5 = new Pedido(p9, b5, 9, "Matheus", 5, new DateTime(2020, 02, 15), Models.Enums.StatusPedido.PegandoBebidaNaCopa);

            _contexto.Pedido.AddRange(P1, P2, P3, P4, P5);

            _contexto.Prato.AddRange(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

            _contexto.Bebida.AddRange(b0, b1, b2, b3, b4, b5);

            _contexto.SaveChanges();
        }
    }
}
