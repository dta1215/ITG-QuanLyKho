using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using QuanLyKho.Models;
using QuanLyKho.Services.DTO;

namespace QuanLyKho.Controllers
{
    public class ChiTietNhapXuatsController : Controller
    {
        private readonly ITGDBContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _host;

        public ChiTietNhapXuatsController(ITGDBContext context,
                                            IHttpClientFactory httpClientFactory,
                                            IWebHostEnvironment webHostEnvironment,
                                            IHttpContextAccessor httpContextAccessor
                                            )
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;

            _host = httpContextAccessor.HttpContext.Request.Host.Value;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search([Bind("SearchTerm")] SearchModel searchModel)
        {
            string searchTerm = searchModel?.SearchTerm?.ToLower();
            TempData["searchTerm"] = searchModel?.SearchTerm;

            var searchResults = _context.ChitietNhapxuats
                                        .AsNoTracking();

            //Nếu không có thì mặc định là hiển thị tất cả danh sách
            if (string.IsNullOrEmpty(searchTerm))
            {
                return View(nameof(Index), searchResults);
            }
            else
            {
                searchResults = searchResults.Where(x => x.ma_vt.ToLower().Contains(searchTerm)
                                                || x.ten_vt.ToLower().Contains(searchTerm));
                return View(nameof(Index), searchResults);
            }
        }

        // GET: ChiTietNhapXuats
        public async Task<IActionResult> Index()
        {
              return _context.ChitietNhapxuats != null ? 
                          View(await _context.ChitietNhapxuats.ToListAsync()) :
                          Problem("Entity set 'ITGDBContext.ChitietNhapxuats'  is null.");
        }

        // GET: ChiTietNhapXuats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChitietNhapxuats == null)
            {
                return NotFound();
            }

            var chiTietNhapXuat = await _context.ChitietNhapxuats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chiTietNhapXuat == null)
            {
                return NotFound();
            }

            return View(chiTietNhapXuat);
        }

        // GET: ChiTietNhapXuats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChiTietNhapXuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,so_phieu,ngay_lap_phieu,ma_vt,ten_vt,dvt,sl_nhap,sl_xuat")] ChiTietNhapXuat chiTietNhapXuat)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    string fullEndPoint = $"https://{_host}/{Constants.APIEndpoint.defaultXuatNhapKhoEndpoint}";
                    var response = await httpClient.PostAsJsonAsync(fullEndPoint, chiTietNhapXuat);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["createdMessage"] = "Thêm mới bản ghi thành công !";
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ChiTietNhapXuats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChitietNhapxuats == null)
            {
                return NotFound();
            }

            var chiTietNhapXuat = await _context.ChitietNhapxuats.FindAsync(id);
            if (chiTietNhapXuat == null)
            {
                return NotFound();
            }
            return View(chiTietNhapXuat);
        }

        // POST: ChiTietNhapXuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,so_phieu,ngay_lap_phieu,ma_vt,ten_vt,dvt,sl_nhap,sl_xuat")] ChiTietNhapXuat chiTietNhapXuat)
        {
            if (id != chiTietNhapXuat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietNhapXuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietNhapXuatExists(chiTietNhapXuat.Id))
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
            return View(chiTietNhapXuat);
        }

        // GET: ChiTietNhapXuats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChitietNhapxuats == null)
            {
                return NotFound();
            }

            var chiTietNhapXuat = await _context.ChitietNhapxuats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chiTietNhapXuat == null)
            {
                return NotFound();
            }

            return View(chiTietNhapXuat);
        }

        // POST: ChiTietNhapXuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                string fullEndPoint = $"https://{_host}/{Constants.APIEndpoint.defaultXuatNhapKhoEndpoint}/{id}";
                var response = await httpClient.DeleteAsync(fullEndPoint);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["successedDelete"] = "Xóa bản ghi thất bại !";
                }
            }

            TempData["successedDelete"] = "Xóa bản ghi thành công !";
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietNhapXuatExists(int id)
        {
          return (_context.ChitietNhapxuats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
