using Events.Infrastructure;

namespace Events.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(EventsDbContext context)
        : base(context) { }
}
