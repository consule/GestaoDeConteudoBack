using System;
using System.Collections.Generic;
using System.IO;
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
    public class BannerPrincipalController : ControllerBase
    {
        private readonly IBannerPrincipalRepository _bannerPrincipalRepository;
        public BannerPrincipalController(IBannerPrincipalRepository bannerPrincipalRepository)
        {
            _bannerPrincipalRepository = bannerPrincipalRepository;
        }
        // GET: api/<BannerPrincipalController>
        [HttpGet]

        public IEnumerable<BannerPrincipal> GetBannerPrincipal()
        {
            return _bannerPrincipalRepository.GetBannerPrincipal();
        }

        // GET api/<BannerPrincipalController>/5
        [HttpGet("{id}")]

        public ActionResult<BannerPrincipal> GetBannerPrincipalPorID(int id)
        {
            var bannerPrincipal = _bannerPrincipalRepository.GetBannerPrincipalPorID(id);

            if (bannerPrincipal == null)
            {
                return NotFound();
            }
            return bannerPrincipal;
        }

        // POST api/<BannerPrincipalController>
        [HttpPost]
        [Authorize]
        public ActionResult<BannerPrincipal> PostBannerPrincipal([FromForm] BannerPrincipal bannerPrincipal)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            string imagem = UploadImagem(bannerPrincipal);

            var banner = new BannerPrincipal
            {
                PrimeiroTitulo = bannerPrincipal.PrimeiroTitulo,
                SegundoTitulo = bannerPrincipal.SegundoTitulo,
                Subtitulo = bannerPrincipal.Subtitulo,
                Chamada = bannerPrincipal.Chamada,
                Link = bannerPrincipal.Link,
                Imagem = imagem,
                Ativo = bannerPrincipal.Ativo

            };

            var bp = _bannerPrincipalRepository.PostBannerPrincipal(banner);
            if (bp == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetBannerPrincipal", new { id = banner.Id }, banner);
        }

        // PUT api/<BannerPrincipalController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult PutBannerPrincipal(int id, [FromForm] BannerPrincipal bannerPrincipal)
        {
            if (id != bannerPrincipal.Id)
            {
                return BadRequest();
            }
            string imagem = UploadImagem(bannerPrincipal);

            var banner = new BannerPrincipal
            {
                Id = id,
                PrimeiroTitulo = bannerPrincipal.PrimeiroTitulo,
                SegundoTitulo = bannerPrincipal.SegundoTitulo,
                Subtitulo = bannerPrincipal.Subtitulo,
                Chamada = bannerPrincipal.Chamada,
                Link = bannerPrincipal.Link,
                Imagem = imagem,
                Ativo = bannerPrincipal.Ativo
            };

            var bp = _bannerPrincipalRepository.PutBannerPrincipal(banner);

            if (!BannerPrincipalExiste(bannerPrincipal.Id))
            {
                return NotFound();
            }                       

            return Ok(bp);
        }
        private string UploadImagem(BannerPrincipal imagem)
        {
            string uniqueFileName = null;
            string caminhoImagem = "assets/images/bannerPrincipal/";

            if (imagem.ImagemFile != null)
            {
                string uploadsFolder = Path.Combine("assets\\images\\bannerPrincipal");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + imagem.ImagemFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagem.ImagemFile.CopyTo(fileStream);
                }
            }
            return caminhoImagem + uniqueFileName;
        }


        // DELETE api/<BannerPrincipalController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteBannerPrincipal(int id)
        {
            if (!BannerPrincipalExiste(id))
            {
                return NotFound();
            }
            var bp = _bannerPrincipalRepository.DeleteBannerPrincipal(id);

            if (bp == null)
            {
                return NotFound();
            }
            return Ok(bp);
        }

        protected bool BannerPrincipalExiste(int id)
        {
            return _bannerPrincipalRepository.BannerPrincipalExiste(id);
        }
    }
}
