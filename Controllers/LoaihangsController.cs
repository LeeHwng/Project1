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
    public class LoaihangsController : Controller
    {
        private readonly QhluxuryContext _context;

        public LoaihangsController(QhluxuryContext context)
        {
            _context = context;
        }

        // GET: Loaihangs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Loaihangs.ToListAsync());
        }

        // GET: Loaihangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Loaihangs == null)
            {
                return NotFound();
            }

            var loaihang = await _context.Loaihangs
                .FirstOrDefaultAsync(m => m.Maloaihang == id);
            if (loaihang == null)
            {
                return NotFound();
            }

            return View(loaihang);
        }

        // GET: Loaihangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loaihangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maloaihang,Tenloaihang")] Loaihang loaihang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaihang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaihang);
        }

        // GET: Loaihangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Loaihangs == null)
            {
                return NotFound();
            }

            var loaihang = await _context.Loaihangs.FindAsync(id);
            if (loaihang == null)
            {
                return NotFound();
            }
            return View(loaihang);
        }

        // POST: Loaihangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Maloaihang,Tenloaihang")] Loaihang loaihang)
        {
            if (id != loaihang.Maloaihang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaihang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaihangExists(loaihang.Maloaihang))
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
            return View(loaihang);
        }

        // GET: Loaihangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Loaihangs == null)
            {
                return NotFound();
            }

            var loaihang = await _context.Loaihangs
                .FirstOrDefaultAsync(m => m.Maloaihang == id);
            if (loaihang == null)
            {
                return NotFound();
            }

            return View(loaihang);
        }

        // POST: Loaihangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Loaihangs == null)
            {
                return Problem("Entity set 'QhluxuryContext.Loaihangs'  is null.");
            }
            var loaihang = await _context.Loaihangs.FindAsync(id);
            if (loaihang != null)
            {
                _context.Loaihangs.Remove(loaihang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaihangExists(int id)
        {
          return _context.Loaihangs.Any(e => e.Maloaihang == id);
        }
    }
}
