using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Crud.Models;

namespace Api_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedidorController : ControllerBase
    {
        private readonly MedidorContextcs _context;

        public MedidorController(MedidorContextcs context)
        {
            _context = context;
        }

        // GET: api/Medidor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medidor>>> GetMedidores()
        {
            return await _context.Medidores.ToListAsync();
        }

        // GET: api/Medidor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medidor>> GetMedidor(int id)
        {
            var medidor = await _context.Medidores.FindAsync(id);

            if (medidor == null)
            {
                return NotFound();
            }

            return medidor;
        }

        // PUT: api/Medidor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedidor(int id, Medidor medidor)
        {
            if (id != medidor.MedidorId)
            {
                return BadRequest();
            }

            _context.Entry(medidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedidorExists(id))
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

        // POST: api/Medidor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medidor>> PostMedidor(Medidor medidor)
        {
            _context.Medidores.Add(medidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedidor", new { id = medidor.MedidorId }, medidor);
        }

        // DELETE: api/Medidor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedidor(int id)
        {
            var medidor = await _context.Medidores.FindAsync(id);
            if (medidor == null)
            {
                return NotFound();
            }

            _context.Medidores.Remove(medidor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedidorExists(int id)
        {
            return _context.Medidores.Any(e => e.MedidorId == id);
        }
    }
}
