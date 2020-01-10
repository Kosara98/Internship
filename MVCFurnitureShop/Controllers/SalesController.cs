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
    public class SalesController : Controller
    {
        private readonly MVCFurnitureShopContext _context;

        public SalesController(MVCFurnitureShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Sales.Include(x => x.ProductSales).ToListAsync());
        }

        public IActionResult Create()
        {
            var clients = new SelectList(_context.Clients.ToList(),"ClientId","Name");
            ViewData["Clients"] = clients;
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var sale = await _context.Sales.FirstOrDefaultAsync(x => x.SaleId == id);

            if (sale == null)
                return NotFound();

            return View(sale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,SaleDate,Invoice")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var sale = await _context.Sales.FindAsync(id);

            if (sale == null)
                return NotFound();
            return View(sale);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("SaleId,SaleDate,Invoice,Product,Quantity,UnitPrice,TotalPrice")] Sale sale)
        //{
        //    if (id != sale.SaleId)
        //        return NotFound();

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(sale);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SaleExists(sale.SaleId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(sale);
        //}

        //private bool SaleExists(int id)
        //{
        //    return _context.Sales.Any(e => e.SaleId == id);
        //}
    }
}
