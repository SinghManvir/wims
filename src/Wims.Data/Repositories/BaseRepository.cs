using Microsoft.EntityFrameworkCore;
using System;

namespace Wims.Data.Repositories
{
    public class BaseRepository
    {
        public DbContext Context { get; }

        public BaseRepository(DbContext defaultContext)
        {
            Context = defaultContext ?? throw new ArgumentNullException(nameof(defaultContext));
        }
    }
}
