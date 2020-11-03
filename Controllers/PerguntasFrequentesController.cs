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
    public class PerguntasFrequentesController : ControllerBase
    {
        private readonly IPerguntasFrequentesRepository _perguntasFrequentesRepository;
        public PerguntasFrequentesController(IPerguntasFrequentesRepository perguntasFrequentesRepo)
        {
            _perguntasFrequentesRepository = perguntasFrequentesRepo;
        }

        // GET: api/PerguntasFrequentes
        [HttpGet]

        public ActionResult<IEnumerable<PerguntasFrequentes>> GetPerguntasFrequentes()
        {
            return _perguntasFrequentesRepository.GetPerguntasFrequentes().ToList();
        }


        [HttpGet("{id}")]
 
        public ActionResult<PerguntasFrequentes> GetPerguntasFrequentesPorID(int id)
        {
            var perguntasFrequentes = _perguntasFrequentesRepository.GetPerguntasFrequentesPorID(id);

            if (perguntasFrequentes == null)
            {
                return NotFound();
            }
            return perguntasFrequentes;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PerguntasFrequentes>> PostPerguntasFrequentes([FromBody] PerguntasFrequentes perguntasFrequentes)
        {

            if (ModelState.IsValid) {
                var pf = _perguntasFrequentesRepository.PostPerguntasFrequentes(perguntasFrequentes);

                if (pf == null)
                {
                    return NotFound();
                }
            }         

            return CreatedAtAction("GetPerguntasFrequentes", new { id = perguntasFrequentes.Id }, perguntasFrequentes);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutPerguntasFrequentes(int id, [FromBody] PerguntasFrequentes perguntasFrequentes)
        {
         
            if (id != perguntasFrequentes.Id)
            {
                return BadRequest();
            }
            var pf = _perguntasFrequentesRepository.PutPerguntasFrequentes(perguntasFrequentes);
            
            if (!PerguntaFrequenteExiste(pf.Id))
            {
                return NotFound();
            }
            return Ok(perguntasFrequentes);
        }

      

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<PerguntasFrequentes>> DeletePerguntasFrequentes(int id)
        {
            if (!PerguntaFrequenteExiste(id))
            {
                return NotFound();
            }
            var pf = _perguntasFrequentesRepository.DeletePerguntasFrequentes(id);
           
            if (pf == null)
            {
                return NotFound();
            }    
            return Ok(pf);
        }

        protected bool PerguntaFrequenteExiste(int id)
        {
            return _perguntasFrequentesRepository.PerguntaFrequenteExiste(id);
        }
    }

       
}
