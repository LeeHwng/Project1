using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Qhluxury.Data;
using Qhluxury.Models;

namespace Qhluxury.Controllers
{
    public class HanghoasController : Controller
    {
        private readonly QhluxuryContext _context;

        public HanghoasController(QhluxuryContext context)
        {
            _context = context;
        }

        // GET: Hanghoas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Hanghoas.ToListAsync());
        }

        // GET: Hanghoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hanghoas == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoas
                .FirstOrDefaultAsync(m => m.Mahang == id);
            if (hanghoa == null)
            {
                return NotFound();
            }

            return View(hanghoa);
        }

        // GET: Hanghoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hanghoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mahang,Tenhang,Maloaihang,Gia,Soluong,Anh")] Hanghoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hanghoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hanghoa);
        }

        // GET: Hanghoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hanghoas == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoas.FindAsync(id);
            if (hanghoa == null)
            {
                return NotFound();
            }
            return View(hanghoa);
        }

        // POST: Hanghoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mahang,Tenhang,Maloaihang,Gia,Soluong,Anh")] Hanghoa hanghoa)
        {
            if (id != hanghoa.Mahang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hanghoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HanghoaExists(hanghoa.Mahang))
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
            return View(hanghoa);
        }

        // GET: Hanghoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hanghoas == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoas
                .FirstOrDefaultAsync(m => m.Mahang == id);
            if (hanghoa == null)
            {
                return NotFound();
            }

            return View(hanghoa);
        }

        // POST: Hanghoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hanghoas == null)
            {
                return Problem("Entity set 'QhluxuryContext.Hanghoas'  is null.");
            }
            var hanghoa = await _context.Hanghoas.FindAsync(id);
            if (hanghoa != null)
            {
                _context.Hanghoas.Remove(hanghoa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HanghoaExists(int id)
        {
          return _context.Hanghoas.Any(e => e.Mahang == id);
        }
    }
}
