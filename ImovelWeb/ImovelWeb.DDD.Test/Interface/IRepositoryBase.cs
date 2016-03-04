using System;
using System.Collections.Generic;
using System.Linq;

namespace ImovelWeb.DDD.Test.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        void Inserir(T model);
        void Atualizar(T model);
        void Excluir(T model);
        void Excluir(int id);
        T PegarID(int id);
        IEnumerable<T> ObterTodos();
        IQueryable<T> Localizar(Func<T, bool> predicate);
     
    }
}
