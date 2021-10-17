using Common.DbFactories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbFactory _dbFactory;
        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());
        }

        public Repository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void Save(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            else
            {
                _dbSet.Remove(entity);
            }
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            //_dbSet.Attach(entity);
            //_ctx.Entry(entity).State = EntityState.Modified;
        }
    }
}
