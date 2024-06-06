using Fdf.APIs.Common;
using Fdf.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fdf.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class UserFindMany : FindManyInput<User, UserWhereInput> { }
