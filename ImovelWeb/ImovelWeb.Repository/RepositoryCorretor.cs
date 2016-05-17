using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImovelWeb.Repository
{
    public class RepositoryCorretor:RepositoryBase<Corretor>,ICorretor
    {
        private readonly DDD.ValueObject.Model.ImovelWeb _db;
        public RepositoryCorretor(DDD.ValueObject.Model.ImovelWeb db_)
            : base(new DDD.ValueObject.Model.ImovelWeb())
        {

            _db = db_;
        }
        public bool Authenticar(string email, string senha)
        {
            var user = false;

            var elemento = (from p in _db.Corretor
                            where p.Email.Equals(email) &&
                                p.Senha.Equals(senha)
                            select p).FirstOrDefault();

            if (elemento != null)
                user = true;
            return user;

        }
    }
}
