using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ImovelWeb.DDD.Interface
{
    public interface IFoto
    {
        void ArquivarFoto(HttpPostedFileBase arquivo,String imovel);
    }
}
