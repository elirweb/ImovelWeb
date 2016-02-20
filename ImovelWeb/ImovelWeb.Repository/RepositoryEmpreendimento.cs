
using ImovelWeb.DDD.Interface;
namespace ImovelWeb.Repository
{
    public class RepositoryEmpreendimento: RepositoryBase<T>,IEmpreendimento
    {
        public RepositoryEmpreendimento():base (){ }
    }
}
