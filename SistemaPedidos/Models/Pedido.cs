using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaPedidos.Models.Enums;

namespace SistemaPedidos.Models
{
    public class Pedido
    {
        public Prato Prato { get; set; }
        public int PratoId { get; set; }
        public Bebida Bebida { get; set; }
        public int BebidaId { get; set; }
        public int Mesa { get; set; }
        public string NomeDoSolicitante { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public StatusPedido Status { get; set; }

        public Pedido()
        {
        }

        public Pedido(Prato prato, Bebida bebida, int mesa, string nomeDoSolicitante, int id, DateTime date, StatusPedido status)
        {
            Prato= prato;
            Bebida = bebida;
            Mesa = mesa;
            NomeDoSolicitante = nomeDoSolicitante;
            Id = id;
            Date = date;
            Status = status;
        }

    }
}
