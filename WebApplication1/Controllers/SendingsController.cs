using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scaffolding.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SendingsController : Controller
    {
        private readonly ScladContext _context;

        public SendingsController(ScladContext context)
        {
            _context = context;
        }

        // GET: Sendings
        public async Task<IActionResult> Index()
        {
            var scladContext = _context.Sendings.Include(s => s.Employee).Include(s => s.Order).Include(s => s.Product).Include(s => s.Provider);
            return View(await scladContext.ToListAsync());
        }

        // GET: Sendings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sending = await _context.Sendings
                .Include(s => s.Employee)
                .Include(s => s.Order)
                .Include(s => s.Product)
                .Include(s => s.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sending == null)
            {
                return NotFound();
            }

            return View(sending);
        }

        // GET: Sendings/Create
        public IActionResult Create()
        {
            ViewData["IdEmployee"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["IdOrder"] = new SelectList(_context.Order, "Id", "Id");
            ViewData["IdProduct"] = new SelectList(_context.Products, "Id", "Id");
            ViewData["IdProvider"] = new SelectList(_context.Providers, "Id", "Id");
            return View();
        }

        // POST: Sendings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProduct,IdOrder,IdProvider,IdEmployee,DateDelivery,DateDeparture")] Sending sending)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sending);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmployee"] = new SelectList(_context.Employees, "Id", "Id", sending.IdEmployee);
            ViewData["IdOrder"] = new SelectList(_context.Order, "Id", "Id", sending.IdOrder);
            ViewData["IdProduct"] = new SelectList(_context.Products, "Id", "Id", sending.IdProduct);
            ViewData["IdProvider"] = new SelectList(_context.Providers, "Id", "Id", sending.IdProvider);
            return View(sending);
        }

        // GET: Sendings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sending = await _context.Sendings.FindAsync(id);
            if (sending == null)
            {
                return NotFound();
            }
            ViewData["IdEmployee"] = new SelectList(_context.Employees, "Id", "Id", sending.IdEmployee);
            ViewData["IdOrder"] = new SelectList(_context.Order, "Id", "Id", sending.IdOrder);
            ViewData["IdProduct"] = new SelectList(_context.Products, "Id", "Id", sending.IdProduct);
            ViewData["IdProvider"] = new SelectList(_context.Providers, "Id", "Id", sending.IdProvider);
            return View(sending);
        }

        // POST: Sendings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProduct,IdOrder,IdProvider,IdEmployee,DateDelivery,DateDeparture")] Sending sending)
        {
            if (id != sending.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sending);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SendingExists(sending.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmployee"] = new SelectList(_context.Employees, "Id", "Id", sending.IdEmployee);
            ViewData["IdOrder"] = new SelectList(_context.Order, "Id", "Id", sending.IdOrder);
            ViewData["IdProduct"] = new SelectList(_context.Products, "Id", "Id", sending.IdProduct);
            ViewData["IdProvider"] = new SelectList(_context.Providers, "Id", "Id", sending.IdProvider);
            return View(sending);
        }

        // GET: Sendings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sending = await _context.Sendings
                .Include(s => s.Employee)
                .Include(s => s.Order)
                .Include(s => s.Product)
                .Include(s => s.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sending == null)
            {
                return NotFound();
            }

            return View(sending);
        }

        // POST: Sendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sending = await _context.Sendings.FindAsync(id);
            _context.Sendings.Remove(sending);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SendingExists(int id)
        {
            return _context.Sendings.Any(e => e.Id == id);
        }
    }
}
