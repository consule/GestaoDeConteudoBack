using ControleDeConteudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Repositories
{
    public interface IBannerDestaqueRepository
    {
        IEnumerable<BannerDestaque> GetBannerDestaque();
        BannerDestaque GetBannerDestaquePorID(int id);
        BannerDestaque PutBannerDestaque(BannerDestaque bannerDestaque);
        BannerDestaque PostBannerDestaque(BannerDestaque bannerDestaque);
        BannerDestaque DeleteBannerDestaque(int id);
        bool BannerDestaqueExiste(int id);
    }
}
