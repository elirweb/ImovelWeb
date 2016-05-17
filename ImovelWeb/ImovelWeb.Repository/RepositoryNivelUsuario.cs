using ImovelWeb.DDD.ValueObject.Model;

namespace ImovelWeb.Repository
{
    public class RepositoryNivelUsuario:RepositoryBase<NivelUsuario>
    {
        public RepositoryNivelUsuario():base(new DDD.ValueObject.Model.ImovelWeb()){ }
    }
}
