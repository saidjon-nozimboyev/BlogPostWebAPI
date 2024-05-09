using BlogPostWebAPI.Entities;
using BlogPostWebAPI.Interfaces.Common;
using System.Linq.Expressions;

namespace BlogPostWebAPI.Interfaces.Repositories;

public interface IUserRepository : ICreatable<User>, IUpdatable<User>, IReadable<User>
{
    Task<User?> GetByEmailAsync(Expression<Func<User, bool>> expression);   
    Task<User?> GetByUsernameAsync(Expression<Func<User, string>> expression);
}
