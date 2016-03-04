using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;

namespace ImovelWeb.Repository
{
    public class RepositoryVendaImovel:RepositoryBase<VendaImovel>,IVendaImovel
    {
        public RepositoryVendaImovel() : base(new DDD.ValueObject.Model.ImovelWeb()) { }
    }
}
