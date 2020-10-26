using ControleDeConteudo.Data;
using ControleDeConteudo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Repositories
{
    public class BannerPrincipalRepository : IBannerPrincipalRepository
    {
        private readonly DataContext _contexto;
        public BannerPrincipalRepository(DataContext ctx)
        {
            _contexto = ctx;
        }

        public IEnumerable<BannerPrincipal> GetBannerPrincipal()
        {
            return _contexto.BannerPrincipal.ToList();
        }


        public BannerPrincipal GetBannerPrincipalPorID(int id)
        {
            return _contexto.BannerPrincipal.Find(id);
        }

        public BannerPrincipal PutBannerPrincipal(BannerPrincipal bannerPrincipal)
        {
            _contexto.Entry(bannerPrincipal).State = EntityState.Modified;

            try
            {
                _contexto.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BannerPrincipalExiste(bannerPrincipal.Id))
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
            return bannerPrincipal;
        }

        public BannerPrincipal PostBannerPrincipal(BannerPrincipal bannerPrincipal)
        {

            //var pf = _contexto.BannerPrincipal.Add(bannerPrincipal);
            _contexto.BannerPrincipal.Add(bannerPrincipal);
            _contexto.SaveChanges();
            return bannerPrincipal;
        }

        public BannerPrincipal DeleteBannerPrincipal(int id)
        {
            var bannerPrincipal = _contexto.BannerPrincipal.Find(id);
            _contexto.BannerPrincipal.Remove(bannerPrincipal);
            _contexto.SaveChanges();
            return bannerPrincipal;
        }


        public bool BannerPrincipalExiste(int id)
        {
            var x = _contexto.BannerPrincipal.Find(id);
            if (x != null)
            {
                return true;
            }
            return false;
        }


    }
}
