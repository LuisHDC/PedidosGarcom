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
using SistemaPedidos.Services;

namespace SistemaPedidos.Controllers
{
    public class MesasController : Controller
    {
        private readonly SistemaPedidosContext _context;
        private readonly PedidoService _pedidoService;
        private readonly MesaService _mesaService;

        public MesasController(SistemaPedidosContext context, PedidoService pedidoService, MesaService mesaService)
        {
            _context = context;
            _pedidoService = pedidoService;
            _mesaService = mesaService;
        }

        // GET: Mesas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mesa.ToListAsync());
        }

        // GET: Mesas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidos = _mesaService.FindPedidosByIDAsync(id.Value);

            if (pedidos.Count == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(pedidos);
        }

        // GET: Mesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mesa);
        }

        // GET: Mesas/Create
        public IActionResult AdicionarPedido(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return RedirectToAction("Create", new RouteValueDictionary(
    new { controller = "Pedidos", action = "Create", Id = id}));
        }

        // GET: Mesas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return RedirectToAction("Edit", new RouteValueDictionary(new { controller = "Pedidos", action = "Edit", Id = id }));
        }

        // GET: Mesas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return RedirectToAction("Delete", new RouteValueDictionary(new { controller = "Pedidos", action = "Delete", Id = id }));
        }
    }
}
