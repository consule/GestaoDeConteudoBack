using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeConteudo.Models;
using ControleDeConteudo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControleDeConteudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        private readonly INoticiasRepository _noticiasRepository;
        public NoticiasController(INoticiasRepository noticiasRepository)
        {
            _noticiasRepository = noticiasRepository;
        }

        // GET: api/<NoticiasController>
        [HttpGet]
        public IEnumerable<Noticias> GetNoticias()
        {
            return _noticiasRepository.GetNoticias();

        }

        // GET api/<NoticiasController>/5
        [HttpGet("{id}")]
        public ActionResult<Noticias> GetNoticiaPorID(int id)
        {
            var noticia = _noticiasRepository.GetNoticiaPorID(id);

            if (noticia == null)
            {
                return NotFound();
            }
            return noticia;
        }

        // POST api/<NoticiasController>
        [HttpPost]
        public ActionResult<Noticias> PostNoticia([FromBody] Noticias noticia)
        {
            var nt = _noticiasRepository.PostNoticias(noticia);
            if (nt == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetNoticias", new { id = noticia.Id }, noticia);
        }

        // PUT api/<NoticiasController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult PutNoticia(int id, [FromBody] Noticias noticia)
        {
            if (id != noticia.Id)
            {
                return BadRequest();
            }
            var not = _noticiasRepository.PutNoticia(noticia);

            if (!NoticiaExiste(noticia.Id))
            {
                return NotFound();
            }
            return Ok(not);
        }

        // DELETE api/<NoticiasController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteNoticia(int id)
        {
            if (!NoticiaExiste(id))
            {
                return NotFound();
            }
            var bp = _noticiasRepository.DeleteNoticia(id);

            if (bp == null)
            {
                return NotFound();
            }
            return Ok(bp);
        }

        protected bool NoticiaExiste(int id)
        {
            return _noticiasRepository.NoticiaExiste(id);
        }
    }
}
