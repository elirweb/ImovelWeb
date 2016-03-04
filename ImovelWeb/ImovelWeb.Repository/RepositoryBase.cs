using System;
using ImovelWeb.DDD.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace ImovelWeb.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>,IDisposable where T : class  
    {
        
        private  DbContext _db = null;
        protected DbSet<T> Table = null;
        public RepositoryBase(DbContext context)
        {
            _db = context;
            Table = _db.Set<T>();
        }
       
        public void Inserir(T model)
        {
            _db.Set<T>().Add(model);
            Salvar();
        }

        public void Atualizar(T model)
        {
            _db.Entry(model).State = EntityState.Modified;
        }

        public void Excluir(T model)
        {
            _db.Set<T>().Remove(model);
        }

        public void Excluir(int id)
        {
            T obj = PegarID(id);
            Excluir(obj);
        }

        public T PegarID(int id)
        {
          return  _db.Set<T>().Find(id);
        }


        public IEnumerable<T> ObterTodos()
        {
            return Table.AsQueryable();
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _db.Dispose();
        }

        public void Salvar()
        {
            _db.SaveChanges();
            Dispose();
        }


        public IQueryable<T> Localizar(Func<T, bool> predicate)
        {
            return Table.Where(predicate).AsQueryable();
        }
    }

}
