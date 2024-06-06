using Microsoft.AspNetCore.Mvc;

namespace Fdf.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
