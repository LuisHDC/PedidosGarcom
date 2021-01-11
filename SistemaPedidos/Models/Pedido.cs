using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Nome do Solicitante")]
        [Required(ErrorMessage = "O nome do solicitante é obrigatório.", AllowEmptyStrings = false)]
        public string NomeDoSolicitante { get; set; }
        public Mesa Mesa { get; set; }
        public int MesaId { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "A data do pedido é obrigatória.")]
        public DateTime Data { get; set; }
        public StatusPedido Status { get; set; }

        public Pedido()
        {
            
        }

        public Pedido(Prato prato, Bebida bebida, Mesa mesa, string nomeDoSolicitante, int id, DateTime data, StatusPedido status)
        {
            Prato = prato;
            Bebida = bebida;
            Mesa = mesa;
            NomeDoSolicitante = nomeDoSolicitante;
            Id = id;
            Data = data;
            Status = status;
        }

    }
}
