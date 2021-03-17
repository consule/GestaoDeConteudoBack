using System;
using System.Collections.Generic;
using System.IO;
using ControleDeConteudo.Models;
using ControleDeConteudo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;

namespace ControleDeConteudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerDestaqueController : ControllerBase
    {
        private readonly IBannerDestaqueRepository _bannerDestaqueRepository;
        public BannerDestaqueController(IBannerDestaqueRepository bannerDestaqueRepository)
        {
            _bannerDestaqueRepository = bannerDestaqueRepository;
        }

        [HttpGet]

        public IEnumerable<BannerDestaque> GetBannerDestaque()
        {
            return _bannerDestaqueRepository.GetBannerDestaque();
        }


        [HttpGet("{id}")]

        public ActionResult<BannerDestaque> GetBannerDestaquePorID(int id)
        {
            var bannerDestaque = _bannerDestaqueRepository.GetBannerDestaquePorID(id);

            if (bannerDestaque == null)
            {
                return NotFound();
            }
            return bannerDestaque;
        }

  
        [HttpPost]
        [Authorize]
        public ActionResult<BannerDestaque> PostBannerDestaque([FromForm] BannerDestaque bannerDestaque)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
     
            string imagem = UploadImagem(bannerDestaque);

                var banner = new BannerDestaque
                {
                    Titulo = bannerDestaque.Titulo,
                    Chamada = bannerDestaque.Chamada,
                    Link = bannerDestaque.Link,
                    Imagem = imagem,
                    Ativo = bannerDestaque.Ativo

                };
                var bd = _bannerDestaqueRepository.PostBannerDestaque(banner);
                if (bd == null)
                {
                    return NotFound();
                }
            return CreatedAtAction("GetBannerDestaque", new { id = banner.Id }, banner);           
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult PutBannerDestaque(int id, [FromForm] BannerDestaque bannerDestaque)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if (id != bannerDestaque.Id)
            {
                return BadRequest();
            }
            string imagem = UploadImagem(bannerDestaque);



            var banner = new BannerDestaque
            {
                Id = id,
                Titulo = bannerDestaque.Titulo,
                Chamada = bannerDestaque.Chamada,
                Link = bannerDestaque.Link,
                Imagem = imagem, 
                Ativo = bannerDestaque.Ativo

            };
            var bp = _bannerDestaqueRepository.PutBannerDestaque(banner);

            if (!BannerDestaqueExiste(bannerDestaque.Id))
            {
                return NotFound();
            }

            return Ok(bp);
        }
        private string UploadImagem(BannerDestaque imagem)
        {
            string uniqueFileName = null;
            string caminhoImagem = "assets/images/bannerDestaque/";

            if (imagem.ImagemFile != null)
            {
                string uploadsFolder = Path.Combine("assets\\images\\bannerDestaque");
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
        public ActionResult DeleteBannerDestaque(int id)
        {
            if (!BannerDestaqueExiste(id))
            {
                return NotFound();
            }
            var bp = _bannerDestaqueRepository.DeleteBannerDestaque(id);

            if (bp == null)
            {
                return NotFound();
            }
            return Ok(bp);
        }

        protected bool BannerDestaqueExiste(int id)
        {
            return _bannerDestaqueRepository.BannerDestaqueExiste(id);
        }

        //Postando Imagem

    }
}
