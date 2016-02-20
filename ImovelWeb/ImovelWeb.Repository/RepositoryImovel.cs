
using ImovelWeb.DDD.Interface;
namespace ImovelWeb.Repository
{
    public class RepositoryImovel:RepositoryBase<T>,ImovelInterface
    {
        public RepositoryImovel():base(){ }
    }
}
