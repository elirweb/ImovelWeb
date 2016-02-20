
using ImovelWeb.DDD.Interface;
namespace ImovelWeb.Repository
{
    public class RepositoryRegistro:RepositoryBase<T>,IRegistro
    {
        public RepositoryRegistro():base(){ }
        public void NovoCorretor()
        {
            throw new System.NotImplementedException();
        }
    }
}
