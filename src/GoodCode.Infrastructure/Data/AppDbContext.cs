using GoodCode.Core.Interfaces;
using GoodCode.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodCode.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<User> Users { get; }

    }
}
