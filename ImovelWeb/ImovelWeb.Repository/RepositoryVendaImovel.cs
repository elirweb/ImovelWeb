using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;
using System.Linq;

namespace ImovelWeb.Repository
{
    public class RepositoryVendaImovel:RepositoryBase<VendaImovel>,IVendaImovel
    {
        private readonly DDD.ValueObject.Model.ImovelWeb _db;
        public RepositoryVendaImovel(DDD.ValueObject.Model.ImovelWeb db_)
            : base(new DDD.ValueObject.Model.ImovelWeb())
        {

            _db = db_;
        }



        public decimal RetornarValor(int? codigo_)
        {
            decimal valorfinal = 0;
            var query = (from p in _db.Imovel
                         where p.ImovelID == codigo_
                         select p.Preco);

            if (query != null) {
                foreach (var elemento in query) {
                    valorfinal = elemento;
                }
            }
                
            return valorfinal;
        }


        public int CodUsuario(string login_)
        {
            int codigo = 0;
            var query = (from p in _db.Usuario
                         where p.Login.Equals(login_)
                         select p.UsuarioID);

            if (query != null)
            {
                foreach (var elemento in query)
                {
                    codigo = elemento;
                }
            }

            return codigo;
        }
    }
}
