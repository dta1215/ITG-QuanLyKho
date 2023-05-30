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
    public class IndexModel : PageModel
    {
        private readonly QuanLyKho.Models.ITGDBContext _context;

        public IndexModel(QuanLyKho.Models.ITGDBContext context)
        {
            _context = context;
        }

        public IList<ChiTietNhapXuat> ChiTietNhapXuat { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ChitietNhapxuats != null)
            {
                ChiTietNhapXuat = await _context.ChitietNhapxuats.ToListAsync();
            }
        }
    }
}
