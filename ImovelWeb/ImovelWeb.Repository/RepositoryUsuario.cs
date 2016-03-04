using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;

namespace ImovelWeb.Repository
{
    public class RepositoryUsuario:RepositoryBase<Usuario>,IUsuario
    {
        public RepositoryUsuario() : base(new DDD.ValueObject.Model.ImovelWeb()) { }
    }
}
