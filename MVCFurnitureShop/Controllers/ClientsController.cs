using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCFurnitureShop.Data;
using MVCFurnitureShop.Models;

namespace MVCFurnitureShop.Controllers
{
    public class ClientsController : Controller
    {
        private readonly MVCFurnitureShopContext _context;

        public ClientsController(MVCFurnitureShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var clients = _context.Clients.Where(x => x.IsDeleted == false).ToListAsync();

            return View(await clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmation([Bind("ClientId,Name,Address,Bulstat,RegisteredVat,Mol")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var client = await _context.Clients
                .FirstOrDefaultAsync(x => x.ClientId == id);

            if (client == null)
                return NotFound();

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ClientId)
        {
            var client = await _context.Clients.FindAsync(ClientId);
            client.IsDeleted = true;
            _context.Update(client);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var client = _context.Clients.Find(id);

            if (client == null)
                return NotFound();

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,Name,Address,RegisteredVat,Mol")] Client client)
        {
            if (client.ClientId != id)
                NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExist(client.ClientId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                NotFound();

            var client = _context.Clients.FirstOrDefault(x => x.ClientId == id);

            if (client == null)
                NotFound();

            return View(client);
        }

        private bool ClientExist(int id)
        {
            return _context.Clients.Any(x => x.ClientId == id);
        }
    }
}