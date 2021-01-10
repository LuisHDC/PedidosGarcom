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
        [Required(ErrorMessage = "O número da mesa é obrigatório e deve ser de 1 a 30.")]
        [Display(Name = "Mesa", Description = "Informe um número de mesa de 1 a 30.")]
        [Range(1, 30)]
        public int Mesa { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "A data do pedido é obrigatória.")]
        public DateTime Data { get; set; }
        public StatusPedido Status { get; set; }

        public Pedido()
        {
            
        }

        public Pedido(Prato prato, Bebida bebida, int mesa, string nomeDoSolicitante, int id, DateTime data, StatusPedido status)
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
