using ControleDeConteudo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Services
{
    public class UploadFileService
    {
       internal static string UploadImagem(BannerDestaque imagem)
        {
            string uniqueFileName = null;
            string caminhoImagem = "assets/images/bannerDestaque/";

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
    }
}
