using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleDeConteudo.Data;
using ControleDeConteudo.Models;

namespace ControleDeConteudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntasFrequentes1Controller : ControllerBase
    {
        private readonly DataContext _context;

        public PerguntasFrequentes1Controller(DataContext context)
        {
            _context = context;
        }

        // GET: api/PerguntasFrequentes1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerguntasFrequentes>>> GetPerguntasFrequentes()
        {
            return await _context.PerguntasFrequentes.ToListAsync();
        }

        // GET: api/PerguntasFrequentes1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PerguntasFrequentes>> GetPerguntasFrequentes(int id)
        {
            var perguntasFrequentes = await _context.PerguntasFrequentes.FindAsync(id);

            if (perguntasFrequentes == null)
            {
                return NotFound();
            }

            return perguntasFrequentes;
        }

        // PUT: api/PerguntasFrequentes1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerguntasFrequentes(int id, PerguntasFrequentes perguntasFrequentes)
        {
            if (id != perguntasFrequentes.Id)
            {
                return BadRequest();
            }
            _context.Entry(perguntasFrequentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerguntasFrequentesExists(id))
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

        // POST: api/PerguntasFrequentes1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PerguntasFrequentes>> PostPerguntasFrequentes(PerguntasFrequentes perguntasFrequentes)
        {
            _context.PerguntasFrequentes.Add(perguntasFrequentes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerguntasFrequentes", new { id = perguntasFrequentes.Id }, perguntasFrequentes);
        }

        // DELETE: api/PerguntasFrequentes1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PerguntasFrequentes>> DeletePerguntasFrequentes(int id)
        {
            var perguntasFrequentes = await _context.PerguntasFrequentes.FindAsync(id);
            if (perguntasFrequentes == null)
            {
                return NotFound();
            }

            _context.PerguntasFrequentes.Remove(perguntasFrequentes);
            await _context.SaveChangesAsync();

            return perguntasFrequentes;
        }

        private bool PerguntasFrequentesExists(int id)
        {
            return _context.PerguntasFrequentes.Any(e => e.Id == id);
        }
    }
}
