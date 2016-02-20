using ImovelWeb.DDD.Interface;

namespace ImovelWeb.Repository
{
    public class RepositoryPorcentagem:RepositoryBase<T>,IPorcentagem
    {
        public RepositoryPorcentagem():base (){ }
    }
}
