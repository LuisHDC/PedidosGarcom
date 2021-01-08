using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidos.Models
{
    public class Prato
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Prato(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
