using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuanLyKho.Models;

namespace QuanLyKho.Controllers
{
    public class DetailsModel : PageModel
    {
        private readonly QuanLyKho.Models.ITGDBContext _context;

        public DetailsModel(QuanLyKho.Models.ITGDBContext context)
        {
            _context = context;
        }

      public ChiTietNhapXuat ChiTietNhapXuat { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ChitietNhapxuats == null)
            {
                return NotFound();
            }

            var chitietnhapxuat = await _context.ChitietNhapxuats.FirstOrDefaultAsync(m => m.Id == id);
            if (chitietnhapxuat == null)
            {
                return NotFound();
            }
            else 
            {
                ChiTietNhapXuat = chitietnhapxuat;
            }
            return Page();
        }
    }
}
