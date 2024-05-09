using BlogPostWebAPI.DbContexts;
using BlogPostWebAPI.Entities;
using BlogPostWebAPI.Interfaces.Repositories;
using System.Linq.Expressions;

namespace BlogPostWebAPI.Repositories;

public class UserRepository(AppDbContext dbContext): IUserRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public Task CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<User>> GetAllAsync(Expression<Func<User, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByEmailAsync(Expression<Func<User, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByUsernameAsync(Expression<Func<User, string>> expression)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
