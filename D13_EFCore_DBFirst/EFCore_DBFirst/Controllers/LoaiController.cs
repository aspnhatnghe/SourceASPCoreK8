using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCore_DBFirst.Models;

namespace EFCore_DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyeStoreContext _context;

        public LoaiController(MyeStoreContext context)
        {
            _context = context;
        }

        // GET: api/Loai
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loai>>> GetLoai()
        {
            return await _context.Loai.ToListAsync();
        }

        // GET: api/Loai/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loai>> GetLoai(int id)
        {
            var loai = _context.Loai
                .Include(p => p.HangHoa)
                .SingleOrDefault(p=> p.MaLoai == id);

            if (loai == null)
            {
                return NotFound();
            }

            return loai;
        }

        // PUT: api/Loai/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoai(int id, Loai loai)
        {
            if (id != loai.MaLoai)
            {
                return BadRequest();
            }

            _context.Entry(loai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Loai
        [HttpPost]
        public async Task<ActionResult<Loai>> PostLoai(Loai loai)
        {
            _context.Loai.Add(loai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoai", new { id = loai.MaLoai }, loai);
        }

        // DELETE: api/Loai/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Loai>> DeleteLoai(int id)
        {
            var loai = await _context.Loai.FindAsync(id);
            if (loai == null)
            {
                return NotFound();
            }

            _context.Loai.Remove(loai);
            await _context.SaveChangesAsync();

            return loai;
        }

        private bool LoaiExists(int id)
        {
            return _context.Loai.Any(e => e.MaLoai == id);
        }
    }
}
