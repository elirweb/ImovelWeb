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
        public RepositoryCorretor() : base(new DDD.ValueObject.Model.ImovelWeb()) { }
        public bool Authenticar(string email, string senha)
        {
            DDD.ValueObject.Model.ImovelWeb db = new DDD.ValueObject.Model.ImovelWeb();
            var user = false;

            var elemento = (from p in db.Corretors
                            where p.Email.Equals(email) &&
                                p.Senha.Equals(senha)
                            select p).FirstOrDefault();

            if (elemento != null)
                user = true;
            return user;

        }
    }
}
