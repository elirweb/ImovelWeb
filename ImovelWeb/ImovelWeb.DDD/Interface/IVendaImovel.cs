using ImovelWeb.DDD.ValueObject.Model;
namespace ImovelWeb.DDD.Interface
{
    public interface IVendaImovel
    {
        decimal RetornarValor(int? codigo_);
        int CodUsuario(string login_);
    }
}
