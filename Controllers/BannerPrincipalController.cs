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
    public class BannerPrincipalController : ControllerBase
    {
        private readonly IBannerPrincipalRepository _bannerPrincipalRepository;
        public BannerPrincipalController(IBannerPrincipalRepository bannerPrincipalRepository)
        {
            _bannerPrincipalRepository = bannerPrincipalRepository;
        }
        // GET: api/<BannerPrincipalController>
        [HttpGet]
        [Authorize]
        public IEnumerable<BannerPrincipal> GetBannerPrincipal()
        {
            return _bannerPrincipalRepository.GetBannerPrincipal();
        }

        // GET api/<BannerPrincipalController>/5
        [HttpGet("{id}")]
        [Authorize]
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
        public ActionResult<BannerPrincipal> PostBannerPrincipal([FromBody] BannerPrincipal bannerPrincipal)
        {
            var bp = _bannerPrincipalRepository.PostBannerPrincipal(bannerPrincipal);
            if (bp == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetBannerPrincipal", new { id = bannerPrincipal.Id }, bannerPrincipal);
        }

        // PUT api/<BannerPrincipalController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult PutBannerPrincipal(int id, [FromBody] BannerPrincipal bannerPrincipal)
        {
            if (id != bannerPrincipal.Id)
            {
                return BadRequest();
            }
            var bp = _bannerPrincipalRepository.PutBannerPrincipal(bannerPrincipal);

            if (!BannerPrincipalExiste(bannerPrincipal.Id))
            {
                return NotFound();
            }                       

            return Ok(bp);


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
