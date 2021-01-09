using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.Data;
using SistemaPedidos.Models;
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
        public async Task<IActionResult> Index()
        {
            var list = await _pedidoService.FindAllAsync();
            return View(list);
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
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

            return View(obj);
        }

        // GET: Pedidos/Create
        public async Task<IActionResult> Create()
        {
            var pratos = await _pratoService.FindAllAsync();
            var bebidas = await _bebidaService.FindAllAsync();
            var viewModel = new PedidosViewModel { Pratos = pratos, Bebidas = bebidas };
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
            await _pedidoService.InsertAsync(pedido);
            return RedirectToAction(nameof(Index));
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
            List<Prato> pratos = await _pratoService.FindAllAsync();
            List<Bebida> bebidas = await _bebidaService.FindAllAsync();
            PedidosViewModel viewModel = new PedidosViewModel { Pedido = obj, Pratos = pratos, Bebidas = bebidas };
            return View(obj);
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
                return RedirectToAction(nameof(Index));
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
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _pedidoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
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
            return View(pedido);
        }

        // POST: Pedidos/AtualizarStatus/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarStatus(int id, Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                var pratos = await _pratoService.FindAllAsync();
                var bebidas = await _bebidaService.FindAllAsync();
                pedido.Status++;
                var viewModel = new PedidosViewModel { Pedido = pedido, Bebidas = bebidas, Pratos = pratos };
                return View(viewModel);
            }
            if (id != pedido.Id)
            {
                return NotFound();
            }
            try
            {
                await _pedidoService.UpdateAsync(pedido);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
                {
                throw new Exception(e.Message);
            }
        }
    }
}
