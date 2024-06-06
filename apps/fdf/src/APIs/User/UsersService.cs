using Fdf.Infrastructure;

namespace Fdf.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(FdfDbContext context)
        : base(context) { }
}
