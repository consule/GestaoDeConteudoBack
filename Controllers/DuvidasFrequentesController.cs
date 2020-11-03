using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeConteudo.Models;
using ControleDeConteudo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeConteudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuvidasFrequentesController : ControllerBase
    {
        private readonly IDuvidasFrequentesRepository _duvidasFrequentesRepository;
        public DuvidasFrequentesController(IDuvidasFrequentesRepository duvidasFrequentesRepo)
        {
            _duvidasFrequentesRepository = duvidasFrequentesRepo;
        }

        // GET: api/DuvidasFrequentes
        [HttpGet]

        public ActionResult<IEnumerable<DuvidasFrequentes>> GetDuvidasFrequentes()
        {
            return _duvidasFrequentesRepository.GetDuvidasFrequentes().ToList();
        }

        // GET: api/DuvidasFrequentes/{id}
        [HttpGet("{id}")]

        public ActionResult<DuvidasFrequentes> GetDuvidasFrequentesPorID(int id)
        {
            var duvidasFrequentes = _duvidasFrequentesRepository.GetDuvidasFrequentesPorID(id);

            if (duvidasFrequentes == null)
            {
                return NotFound();
            }
            return duvidasFrequentes;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<DuvidasFrequentes>> PostDuvidasFrequentes([FromBody] DuvidasFrequentes duvidasFrequentes)
        {
            var pf = _duvidasFrequentesRepository.PostDuvidasFrequentes(duvidasFrequentes);

            if (pf == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetDuvidasFrequentes", new { id = duvidasFrequentes.Id }, duvidasFrequentes);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutDuvidasFrequentes(int id, [FromBody] DuvidasFrequentes duvidasFrequentes)
        {
         
            if (id != duvidasFrequentes.Id)
            {
                return BadRequest();
            }
            var pf = _duvidasFrequentesRepository.PutDuvidasFrequentes(duvidasFrequentes);
            
            if (!PerguntaFrequenteExiste(pf.Id))
            {
                return NotFound();
            }
            return Ok(duvidasFrequentes);
        }

      

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<DuvidasFrequentes>> DeleteDuvidasFrequentes(int id)
        {
            if (!PerguntaFrequenteExiste(id))
            {
                return NotFound();
            }
            var pf = _duvidasFrequentesRepository.DeleteDuvidasFrequentes(id);
           
            if (pf == null)
            {
                return NotFound();
            }    
            return Ok(pf);
        }

        protected bool PerguntaFrequenteExiste(int id)
        {
            return _duvidasFrequentesRepository.DuvidaFrequenteExiste(id);
        }
    }

       
}
