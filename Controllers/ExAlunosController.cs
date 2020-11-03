using System;
using System.Collections.Generic;
using System.IO;
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

        public IEnumerable<ExAlunos> GetExAlunos()
        {
            return _exAlunoRepository.GetExAlunos();
        }


        [HttpGet("{id}")]

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
        public ActionResult<ExAlunos> PostExAluno([FromForm] ExAlunos exAluno)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            string imagem = UploadImagem(exAluno);

            var exAlunoNew = new ExAlunos
            {
                NomeAluno = exAluno.NomeAluno,
                Ano = exAluno.Ano,
                Sala = exAluno.Sala,
                AprovadoEm = exAluno.AprovadoEm,
                Testemunho = exAluno.Testemunho,
                Imagem = imagem,
                Ativo = exAluno.Ativo

            };
            var x = _exAlunoRepository.PostExAlunos(exAlunoNew);
            if (x == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetExAlunos", new { id = exAlunoNew.Id }, exAlunoNew);
        }

     
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult PutExAlunos(int id, [FromForm] ExAlunos exAluno)
        {
           
            if (id != exAluno.Id)
            {
                return BadRequest();
            }
            string imagem = UploadImagem(exAluno);

            var exAlunoNew = new ExAlunos
            {
                Id = id,
                NomeAluno = exAluno.NomeAluno,
                Ano = exAluno.Ano,
                Sala = exAluno.Sala,
                AprovadoEm = exAluno.AprovadoEm,
                Testemunho = exAluno.Testemunho,
                Imagem = imagem,
                Ativo = exAluno.Ativo

            };
            var exaluno = _exAlunoRepository.PutExAlunos(exAlunoNew);

            if (!ExAlunosExiste(exAlunoNew.Id))
            {
                return NotFound();
            }

            return Ok(exaluno);
        }
        private string UploadImagem(ExAlunos imagem)
        {
            string uniqueFileName = null;
            string caminhoImagem = "assets/images/exAlunos/";

            if (imagem.ImagemFile != null)
            {
                string uploadsFolder = Path.Combine("assets\\images\\exAlunos");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + imagem.ImagemFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagem.ImagemFile.CopyTo(fileStream);
                }
            }
            return caminhoImagem + uniqueFileName;
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
