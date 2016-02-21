
using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;
namespace ImovelWeb.Repository
{
    public class RepositoryEmpreendimento: RepositoryBase<Empreendimento>,IEmpreendimento
    {
        public RepositoryEmpreendimento() : base(new DDD.ValueObject.Model.ImovelWeb()) { }
    }
}
