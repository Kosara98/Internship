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

        public async Task<IActionResult> DeleteConfirmed(int ClientId)
        {
            var client = await _context.Clients.FindAsync(ClientId);
            client.IsDeleted = true;
            _context.Update(client);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}