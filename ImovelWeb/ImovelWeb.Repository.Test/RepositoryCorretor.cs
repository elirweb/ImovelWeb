using ImovelWeb.DDD.Test.Interface;
using ImovelWeb.DDD.Test.ValueObject.Model;
using System;

namespace ImovelWeb.Repository.Test
{
    public class RepositoryCorretor:RepositoryBase<Corretor>,ICorretor
    {
        public RepositoryCorretor() : base(new DDD.Test.ValueObject.Model.ImovelWeb()) { }
        public bool Authenticar(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
