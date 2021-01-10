using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidos.Models
{
    public class Bebida
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Bebida()
        {

        }
        public Bebida(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
