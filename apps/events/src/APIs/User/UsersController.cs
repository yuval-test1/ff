using Microsoft.AspNetCore.Mvc;

namespace Events.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
