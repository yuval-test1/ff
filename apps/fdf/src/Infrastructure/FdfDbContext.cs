using Fdf.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Fdf.Infrastructure;

public class FdfDbContext : IdentityDbContext<User>
{
    public FdfDbContext(DbContextOptions<FdfDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
}
