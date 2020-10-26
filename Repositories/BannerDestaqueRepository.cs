using ControleDeConteudo.Data;
using ControleDeConteudo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Repositories
{
    public class BannerDestaqueRepository : IBannerDestaqueRepository
    {
        private readonly DataContext _contexto;
        public BannerDestaqueRepository(DataContext ctx)
        {
            _contexto = ctx;
        }

        public IEnumerable<BannerDestaque> GetBannerDestaque()
        {
            return _contexto.BannerDestaque.ToList();
        }


        public BannerDestaque GetBannerDestaquePorID(int id)
        {
            return _contexto.BannerDestaque.Find(id);
        }

        public BannerDestaque PutBannerDestaque(BannerDestaque bannerDestaque)
        {
            _contexto.Entry(bannerDestaque).State = EntityState.Modified;

            try
            {
                _contexto.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BannerDestaqueExiste(bannerDestaque.Id))
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
            return bannerDestaque;
        }

        public BannerDestaque PostBannerDestaque(BannerDestaque bannerDestaque)
        {

            //var pf = _contexto.BannerDestaque.Add(bannerDestaque);
            _contexto.BannerDestaque.Add(bannerDestaque);
            _contexto.SaveChanges();
            return bannerDestaque;
        }

        public BannerDestaque DeleteBannerDestaque(int id)
        {
            var bannerDestaque = _contexto.BannerDestaque.Find(id);
            _contexto.BannerDestaque.Remove(bannerDestaque);
            _contexto.SaveChanges();
            return bannerDestaque;
        }


        public bool BannerDestaqueExiste(int id)
        {
            var x = _contexto.BannerDestaque.Find(id);
            if (x != null)
            {
                return true;
            }
            return false;
        }
    }
}
