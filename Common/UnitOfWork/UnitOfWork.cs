using Common.DbFactories;
using Common.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private DbFactory<TContext> _dbFactory;

        public UnitOfWork(DbFactory<TContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public Task CommitAsync()
        {
            return _dbFactory.Context.SaveChangesAsync();
        }
    }
}
