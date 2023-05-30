using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyKho.Models;

namespace QuanLyKho.Controllers
{
    public class CreateModel : PageModel
    {
        private readonly QuanLyKho.Models.ITGDBContext _context;

        public CreateModel(QuanLyKho.Models.ITGDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ChiTietNhapXuat ChiTietNhapXuat { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ChitietNhapxuats == null || ChiTietNhapXuat == null)
            {
                return Page();
            }

            _context.ChitietNhapxuats.Add(ChiTietNhapXuat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
