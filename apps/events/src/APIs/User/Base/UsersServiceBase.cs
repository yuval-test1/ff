using Events.APIs;
using Events.APIs.Common;
using Events.APIs.Dtos;
using Events.APIs.Errors;
using Events.APIs.Extensions;
using Events.Infrastructure;
using Events.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Events.APIs;

public abstract class UsersServiceBase : IUsersService
{
    protected readonly EventsDbContext _context;

    public UsersServiceBase(EventsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one User
    /// </summary>
    public async Task<UserDto> CreateUser(UserCreateInput createDto)
    {
        var user = new User
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            FirstName = createDto.FirstName,
            LastName = createDto.LastName,
            Username = createDto.Username,
            Email = createDto.Email,
            Password = createDto.Password,
            Roles = createDto.Roles
        };

        if (createDto.Id != null)
        {
            user.Id = createDto.Id;
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<User>(user.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one User
    /// </summary>
    public async Task DeleteUser(UserIdDto idDto)
    {
        var user = await _context.Users.FindAsync(idDto.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Users
    /// </summary>
    public async Task<List<UserDto>> Users(UserFindMany findManyArgs)
    {
        var users = await _context
            .Users.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return users.ConvertAll(user => user.ToDto());
    }

    /// <summary>
    /// Get one User
    /// </summary>
    public async Task<UserDto> User(UserIdDto idDto)
    {
        var users = await this.Users(
            new UserFindMany { Where = new UserWhereInput { Id = idDto.Id } }
        );
        var user = users.FirstOrDefault();
        if (user == null)
        {
            throw new NotFoundException();
        }

        return user;
    }

    /// <summary>
    /// Update one User
    /// </summary>
    public async Task UpdateUser(UserIdDto idDto, UserUpdateInput updateDto)
    {
        var user = updateDto.ToModel(idDto);

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Users.Any(e => e.Id == user.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
