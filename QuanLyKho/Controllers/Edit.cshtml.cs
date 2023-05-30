using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyKho.Models;

namespace QuanLyKho.Controllers
{
    public class EditModel : PageModel
    {
        private readonly QuanLyKho.Models.ITGDBContext _context;

        public EditModel(QuanLyKho.Models.ITGDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChiTietNhapXuat ChiTietNhapXuat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ChitietNhapxuats == null)
            {
                return NotFound();
            }

            var chitietnhapxuat =  await _context.ChitietNhapxuats.FirstOrDefaultAsync(m => m.Id == id);
            if (chitietnhapxuat == null)
            {
                return NotFound();
            }
            ChiTietNhapXuat = chitietnhapxuat;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ChiTietNhapXuat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietNhapXuatExists(ChiTietNhapXuat.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChiTietNhapXuatExists(int id)
        {
          return (_context.ChitietNhapxuats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
