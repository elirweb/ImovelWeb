using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImovelWeb.Repository
{
    public class RepositoryImobiliario:RepositoryBase<NivelUsuario>,ImovelInterface
    {
        public RepositoryImobiliario() : base(new DDD.ValueObject.Model.ImovelWeb()) { }
    }
}
