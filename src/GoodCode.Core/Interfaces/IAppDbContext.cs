using GoodCode.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodCode.Core.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; }
        int SaveChanges();
    }
}
