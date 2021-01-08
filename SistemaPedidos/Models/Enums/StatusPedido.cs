using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidos.Models.Enums
{
    public enum StatusPedido : int
    {
        Pendente = 0,
        VisualizadoPelaCozinha = 1,
        PegandoBebidaNaCopa = 2,
        PratoPronto = 3,
        Entregue = 4
    }
}
