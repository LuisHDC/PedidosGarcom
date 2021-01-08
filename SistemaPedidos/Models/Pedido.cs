using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaPedidos.Models.Enums;

namespace SistemaPedidos.Models
{
    public class Pedido
    {
        public Dictionary<int, string> Cardapio = new Dictionary<int, string>();
        public Dictionary<int, string> CardapioBebidas = new Dictionary<int, string>();
        public string Prato { get; set; }
        public string Bebida { get; set; }
        public int Mesa { get; set; }
        public string NomeDoSolicitante { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public StatusPedido Status { get; set; }

        public Pedido()
        {
        }

        public Pedido(int codPrato, int codBebida, int mesa, string nomeDoSolicitante, DateTime date, int id, StatusPedido status)
        {
            PreencherCardapio();
            Prato = Cardapio[codPrato];
            Bebida = CardapioBebidas[codBebida];
            Mesa = mesa;
            NomeDoSolicitante = nomeDoSolicitante;
            Id = id;
            Date = date;
            Status = status;
        }

        public void PreencherCardapio()
        {
            Cardapio.Add(0, "Nada");
            Cardapio.Add(1, "Macarronada");
            Cardapio.Add(2, "Feijoada");
            Cardapio.Add(3, "Frango a Passarinho");
            Cardapio.Add(4, "Milanesa");
            Cardapio.Add(5, "Salada");
            Cardapio.Add(6, "Lasanha");
            Cardapio.Add(7, "Vaca Atolada");
            Cardapio.Add(8, "Buchada de Bode");
            Cardapio.Add(9, "Tropeiro");
            Cardapio.Add(10, "Nhoque");

            CardapioBebidas.Add(0, "Nada");
            CardapioBebidas.Add(1, "Coca-Cola");
            CardapioBebidas.Add(2, "Guaraná");
            CardapioBebidas.Add(3, "Fanta");
            CardapioBebidas.Add(4, "Água com gás");
            CardapioBebidas.Add(5, "Água Mineral");
        }
    }
}
