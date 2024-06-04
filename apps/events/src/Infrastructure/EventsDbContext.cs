using Events.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure;

public class EventsDbContext : IdentityDbContext<User>
{
    public EventsDbContext(DbContextOptions<EventsDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
}
