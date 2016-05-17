
using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;
using System.Web;
namespace ImovelWeb.Repository
{
    public class RepositorioFoto : RepositoryBase<Foto>,IFoto
    {
        public RepositorioFoto():base (new DDD.ValueObject.Model.ImovelWeb()){ }

        public void ArquivarFoto(HttpPostedFileBase arquivo, string imovel)
        {
            if (arquivo != null && arquivo.ContentLength > 0)
            {
                var Ext = System.IO.Path.GetExtension(arquivo.FileName);
                if (Ext.ToLower() == ".jpg" || Ext.ToLower() == ".gif" ||
                    Ext.ToLower() == ".jpeg" || Ext.ToLower() == ".png")
                {
                    var diretorio = HttpContext.Current.Server.MapPath("~/") + "Fotos/" + imovel + "/";
                    if (System.IO.Directory.Exists(diretorio))
                    {
                        arquivo.SaveAs(diretorio + System.IO.Path.GetFileName(arquivo.FileName.ToLower()));
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(diretorio);
                        arquivo.SaveAs(diretorio + System.IO.Path.GetFileName(arquivo.FileName.ToLower()));

                    }
                }

            }
        }

        
    }
}
