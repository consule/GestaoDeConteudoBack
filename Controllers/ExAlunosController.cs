using System.Collections.Generic;
using ControleDeConteudo.Models;
using ControleDeConteudo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ControleDeConteudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExAlunosController : ControllerBase
    {
        private readonly IExAlunosRepository _exAlunoRepository;
        public ExAlunosController(IExAlunosRepository exAlunoRepository)
        {
            _exAlunoRepository = exAlunoRepository;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<ExAlunos> GetExAluno()
        {
            return _exAlunoRepository.GetExAlunos();
        }


        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<ExAlunos> GetExAlunoPorID(int id)
        {
            var exAluno = _exAlunoRepository.GetExAlunosPorID(id);

            if (exAluno == null)
            {
                return NotFound();
            }
            return exAluno;
        }

  
        [HttpPost]
        [Authorize]
        public ActionResult<ExAlunos> PostExAluno([FromBody] ExAlunos exAluno)
        {
            var bd = _exAlunoRepository.PostExAlunos(exAluno);
            if (bd == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetExAlunos", new { id = exAluno.Id }, exAluno);
        }

     
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult PutExAlunos(int id, [FromBody] ExAlunos exAluno)
        {
            if (id != exAluno.Id)
            {
                return BadRequest();
            }
            var bp = _exAlunoRepository.PutExAlunos(exAluno);

            if (!ExAlunosExiste(exAluno.Id))
            {
                return NotFound();
            }

            return Ok(bp);


        }

 
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteExAlunos(int id)
        {
            if (!ExAlunosExiste(id))
            {
                return NotFound();
            }
            var bp = _exAlunoRepository.DeleteExAlunos(id);

            if (bp == null)
            {
                return NotFound();
            }
            return Ok(bp);
        }

        protected bool ExAlunosExiste(int id)
        {
            return _exAlunoRepository.ExAlunosExiste(id);
        }
    }
}
