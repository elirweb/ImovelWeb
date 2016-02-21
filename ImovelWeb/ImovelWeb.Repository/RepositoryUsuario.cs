using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImovelWeb.Repository
{
    public class RepositoryUsuario:RepositoryBase<Usuario>,IUsuario
    {
        public RepositoryUsuario() : base(new DDD.ValueObject.Model.ImovelWeb()) { }
    }
}
