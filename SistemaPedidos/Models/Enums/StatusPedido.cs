using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidos.Models.Enums
{
    public enum StatusPedido : int
    {
        Pendete = 0,
        Visualizado = 1,
        PegandoBebida = 2,
        PratoPronto = 3,
        Entregue = 4
    }
}
