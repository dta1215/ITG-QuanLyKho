using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKho.Models;

namespace QuanLyKho.Controllers
{
    [ApiController]
    [Route("api/xuatnhapkho")]
    public class NhapXuatKhoAPIController : ControllerBase
    {
        private readonly ITGDBContext _context;

        public NhapXuatKhoAPIController(ITGDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.ChitietNhapxuats.FindAsync(id);
            if(item != null)
            {
                return Ok(item);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChiTietNhapXuat chiTietNhapXuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietNhapXuat);
                await _context.SaveChangesAsync();

                return Ok("Thêm mới bản ghi thành công !");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var chiTietNhapXuat = await _context.ChitietNhapxuats.FindAsync(id);

            if(chiTietNhapXuat is null)
            {
                return BadRequest("Không tìm thấy bản ghi này !");
            }

            _context.ChitietNhapxuats.Remove(chiTietNhapXuat);
            await _context.SaveChangesAsync();

            return Ok("Xóa bản ghi thành công !");
        }
    }
}
