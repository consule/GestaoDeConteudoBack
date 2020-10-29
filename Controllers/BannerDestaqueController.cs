using System.Collections.Generic;
using ControleDeConteudo.Models;
using ControleDeConteudo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
        [Authorize]
        public IEnumerable<BannerDestaque> GetBannerDestaque()
        {
            return _bannerDestaqueRepository.GetBannerDestaque();
        }


        [HttpGet("{id}")]
        [Authorize]
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
        public ActionResult<BannerDestaque> PostBannerDestaque([FromBody] BannerDestaque bannerDestaque)
        {
            var bd = _bannerDestaqueRepository.PostBannerDestaque(bannerDestaque);
            if (bd == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetBannerDestaque", new { id = bannerDestaque.Id }, bannerDestaque);
        }

     
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult PutBannerDestaque(int id, [FromBody] BannerDestaque bannerDestaque)
        {
            if (id != bannerDestaque.Id)
            {
                return BadRequest();
            }
            var bp = _bannerDestaqueRepository.PutBannerDestaque(bannerDestaque);

            if (!BannerDestaqueExiste(bannerDestaque.Id))
            {
                return NotFound();
            }

            return Ok(bp);


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
    }
}
