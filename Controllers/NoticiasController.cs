using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeConteudo.Models;
using ControleDeConteudo.Repositories;
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
        public string Get(int id)
        {
            return "value";
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NoticiasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
