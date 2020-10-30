using System.Collections.Generic;
using ControleDeConteudo.Models;
using ControleDeConteudo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControleDeConteudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<Categoria>> GetCategoria()
        {
            return _categoriaRepository.GetCategoria();
        }


        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Categoria> GetCategoriaPorID(int id)
        {
            var categoria = _categoriaRepository.GetCategoriaPorID(id);

            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }


        [HttpPost]
        [Authorize]
        public ActionResult<Categoria> PostCategoria([FromBody] Categoria categoria)
        {
            var bd = _categoriaRepository.PostCategoria(categoria);
            if (bd == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }


        [HttpPut("{id}")]
        [Authorize]
        public ActionResult PutCategoria(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }
            var bp = _categoriaRepository.PutCategoria(categoria);

            if (!CategoriaExiste(categoria.Id))
            {
                return NotFound();
            }

            return Ok(bp);

        }


        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteCategoria(int id)
        {
            if (!CategoriaExiste(id))
            {
                return NotFound();
            }
            var bp = _categoriaRepository.DeleteCategoria(id);

            if (bp == null)
            {
                return NotFound();
            }
            return Ok(bp);
        }

        protected bool CategoriaExiste(int id)
        {
            return _categoriaRepository.CategoriaExiste(id);
        }
    }
}
