using ImovelWeb.DDD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImovelWeb.Repository
{
    public class RepositoryCorretor:RepositoryBase<T>,ICorretor
    {
        public RepositoryCorretor():base(){ }
        public bool Authenticar(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
