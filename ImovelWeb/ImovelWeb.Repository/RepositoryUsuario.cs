using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;
using System.Linq;
namespace ImovelWeb.Repository
{
    public class RepositoryUsuario:RepositoryBase<Usuario>,IUsuario
    {
        private readonly DDD.ValueObject.Model.ImovelWeb _db;
        public RepositoryUsuario(DDD.ValueObject.Model.ImovelWeb db_)
            : base(new DDD.ValueObject.Model.ImovelWeb())
        {
            _db = db_;
        }

        public bool Authenticar(string login, string senha)
        {
            var user = false;

            var elemento = (from p in _db.Usuario
                            where p.Login.Equals(login) &&
                                p.Senha.Equals(senha)
                            select p).FirstOrDefault();
                

            if (elemento != null)
                user = true;
            return user;

        }
    }
}
