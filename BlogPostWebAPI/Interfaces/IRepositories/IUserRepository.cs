namespace BlogPostWebAPI.Interfaces.Repositories;

public interface IUserRepository : ICreatable<User>, IUpdatable<User>, IReadable<User>
{
    Task<User?> GetByEmailAsync(Expression<Func<User, bool>> expression);
    Task<User?> GetByUsernameAsync(Expression<Func<User, bool>> expression);
}