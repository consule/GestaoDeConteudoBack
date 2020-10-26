using ControleDeConteudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Repositories
{
    public interface IBannerPrincipalRepository
    {
        IEnumerable<BannerPrincipal> GetBannerPrincipal();
        BannerPrincipal GetBannerPrincipalPorID(int id);
        BannerPrincipal PutBannerPrincipal(BannerPrincipal bannerPrincipal);
        BannerPrincipal PostBannerPrincipal(BannerPrincipal bannerPrincipal);
        BannerPrincipal DeleteBannerPrincipal(int id);
        bool BannerPrincipalExiste(int id);
    }

}
