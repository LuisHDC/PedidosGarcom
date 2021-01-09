using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidos.Models
{
    public class Bebida
    {
        public string Nome { get; set; }
        public int Id { get; set; }

        public Bebida()
        {

        }
        public Bebida(string nome, int id)
        {
            Nome = nome;
            Id = id;
        }
    }
}
