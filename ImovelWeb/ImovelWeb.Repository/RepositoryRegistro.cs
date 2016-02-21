
using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;
namespace ImovelWeb.Repository
{
    public class RepositoryRegistro:RepositoryBase<Registro>,IRegistro
    {
        public RepositoryRegistro() : base(new DDD.ValueObject.Model.ImovelWeb()) { }
        public void NovoCorretor()
        {
            throw new System.NotImplementedException();
        }
    }
}
