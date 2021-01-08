using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidos.Models
{
    public class Bebida
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public Bebida(int iD, string nome)
        {
            ID = iD;
            Nome = nome;
        }
    }
}
