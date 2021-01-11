using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Data;
using SistemaPedidos.Models;
using SistemaPedidos.Models.Enums;
using SistemaPedidos.Models.ViewModels;
using SistemaPedidos.Services;

namespace SistemaPedidos.Controllers
{
    public class PedidosController : Controller
    {
        private readonly PedidoService _pedidoService;
        private readonly PratoService _pratoService;
        private readonly BebidaService _bebidaService;

        public PedidosController(PedidoService pedidosService, PratoService pratoService, BebidaService bebidaService)
        {
            _pedidoService = pedidosService;
            _pratoService = pratoService;
            _bebidaService = bebidaService;
        }

        // GET: Pedidos
        public IActionResult Index(int? id)
        {
            return RedirectToAction("Details", new RouteValueDictionary(
     new { controller = "Mesas", action = "Details", Id = id}));
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pratos = await _pratoService.FindAllAsync();
            var bebidas = await _bebidaService.FindAllAsync();
            var obj = await _pedidoService.FindByIDAsync(id.Value);
            var viewModel = new PedidosViewModel { Pedido = obj,Pratos = pratos, Bebidas = bebidas };
            if (obj == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Pedidos/Create
        public async Task<IActionResult> Create(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var pratos = await _pratoService.FindAllAsync();
            var bebidas = await _bebidaService.FindAllAsync();
            var pedido = new Pedido { MesaId=Id.Value };
            var viewModel = new PedidosViewModel { Pedido = pedido,  Pratos = pratos, Bebidas = bebidas };
            return View(viewModel);
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                var pratos = await _pratoService.FindAllAsync();
                var bebidas = await _bebidaService.FindAllAsync();
                var viewModel = new PedidosViewModel { Pedido = pedido, Pratos = pratos, Bebidas = bebidas };
                return View(viewModel);
            }
            pedido.Status = StatusPedido.Pendente;
            await _pedidoService.InsertAsync(pedido);
            return RedirectToAction("Details", new RouteValueDictionary(
     new { controller = "Mesas", action = "Details", Id = pedido.MesaId}));
        }

            // GET: Pedidos/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _pedidoService.FindByIDAsync(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            var pratos = await _pratoService.FindAllAsync();
            var bebidas = await _bebidaService.FindAllAsync();
            var viewModel = new PedidosViewModel { Pedido = obj, Pratos = pratos, Bebidas = bebidas };
            return View(viewModel);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                List<Prato> pratos = await _pratoService.FindAllAsync();
                List<Bebida> bebidas = await _bebidaService.FindAllAsync();
                PedidosViewModel viewModel = new PedidosViewModel { Pedido = pedido, Pratos = pratos, Bebidas = bebidas };
                return View(viewModel);
            }
            if (id != pedido.Id)
            {
                return NotFound();
            }
            try
            {

                await _pedidoService.UpdateAsync(pedido);
                return RedirectToAction("Details", new RouteValueDictionary(
     new { controller = "Mesas", action = "Details", Id = pedido.MesaId }));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _pedidoService.FindByIDAsync(id.Value);
            var pratos = await _pratoService.FindAllAsync();
            var bebidas = await _bebidaService.FindAllAsync();
            var viewModel = new PedidosViewModel { Pedido = obj, Pratos = pratos, Bebidas = bebidas };
            if (obj == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Pedido pedido = await _pedidoService.FindByIDAsync(id);
                await _pedidoService.RemoveAsync(id);
                return RedirectToAction("Details", new RouteValueDictionary(
     new { controller = "Mesas", action = "Details", Id = pedido.MesaId }));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: Pedidos/AtualizarStatus/5
        public async Task<IActionResult> AtualizarStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _pedidoService.FindByIDAsync(id.Value);
            if (pedido == null)
            {
                return NotFound();
            }
            if (pedido.Status < StatusPedido.Entregue)
                pedido.Status++;
                await _pedidoService.UpdateAsync(pedido);
            return RedirectToAction("Details", new RouteValueDictionary(
     new { controller = "Mesas", action = "Details", Id = pedido.MesaId }));
        }
    }
}
