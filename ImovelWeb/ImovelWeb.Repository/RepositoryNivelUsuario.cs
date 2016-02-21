using ImovelWeb.DDD.ValueObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImovelWeb.Repository
{
    public class RepositoryNivelUsuario:RepositoryBase<NivelUsuario>
    {
        public RepositoryNivelUsuario():base(new DDD.ValueObject.Model.ImovelWeb()){ }
    }
}
