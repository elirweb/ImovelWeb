using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;
using System.Text;
namespace ImovelWeb.Repository
{
    public class RepositoryPorcentagem:RepositoryBase<Porcentagem>,IPorcentagem
    {
        public RepositoryPorcentagem() : base(new DDD.ValueObject.Model.ImovelWeb()) { }

        public double PorcentagemImovel(double valor, string desconto)
        {
            return (double.Parse(desconto) / 100) * valor;
        }
    }
}
