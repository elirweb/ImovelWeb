using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;

namespace ImovelWeb.Repository
{
    public class RepositoryPorcentagem:RepositoryBase<Porcentagem>,IPorcentagem
    {
        public RepositoryPorcentagem() : base(new DDD.ValueObject.Model.ImovelWeb()) { }
    }
}
