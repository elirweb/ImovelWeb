
using ImovelWeb.DDD.Interface;
using System.Web;
namespace ImovelWeb.Repository
{
    public class RepositorioFoto : RepositoryBase<T>,IFoto
    {
        public RepositorioFoto():base (){ }

        public void ArquivarFoto(HttpPostedFileBase arquivo, string imovel)
        {
            if (arquivo != null && arquivo.ContentLength > 0)
            {
                var Ext = System.IO.Path.GetExtension(arquivo.FileName);
                if (Ext.ToLower() == ".jpg" || Ext.ToLower() == ".gif" ||
                    Ext.ToLower() == ".jpeg" || Ext.ToLower() == ".png")
                {
                    var diretorio = HttpContext.Current.Server.MapPath("~/") + "Fotos/" + imovel.Replace(" ", "_") + "/";
                    if (System.IO.Directory.Exists(diretorio))
                    {
                        arquivo.SaveAs(diretorio + System.IO.Path.GetFileName(arquivo.FileName));
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(diretorio);
                        arquivo.SaveAs(diretorio + System.IO.Path.GetFileName(arquivo.FileName));

                    }
                }

            }
        }
    }
}
