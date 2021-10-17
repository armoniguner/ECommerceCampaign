using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DbFactories
{
    public class DbFactory<TContext> : IDbFactory<TContext> where TContext : DbContext
    {
        private bool _disposed;
        private Func<TContext> _instanceFunc;
        private TContext _context;
        public TContext Context => _context ?? (_context = _instanceFunc.Invoke());

        public DbFactory(Func<TContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }
    }
}
