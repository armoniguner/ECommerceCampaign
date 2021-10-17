using Microsoft.EntityFrameworkCore;

namespace Common.DbFactories
{
    public interface IDbFactory<TContext> where TContext : DbContext
    {
        TContext Context { get; }
    }
}
