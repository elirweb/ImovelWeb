using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ImovelWeb.Repository.Test
{
    public interface ICorretorRepositoryTest
    {
        IList<DDD.Test.ValueObject.Model.Corretor>Corretor { get; }
    }
}
