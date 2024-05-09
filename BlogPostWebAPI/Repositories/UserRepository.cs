namespace BlogPostWebAPI.Repositories;
#pragma warning disable
public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task CreateAsync(User entity)
    {
        await _dbContext.Users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IQueryable<User>> GetAllAsync(Expression<Func<User, bool>> expression)
        => _dbContext.Users.Where(expression);

    public async Task<User?> GetByEmailAsync(Expression<Func<User, bool>> expression)
        => await _dbContext.Users.FirstOrDefaultAsync(expression);

    public async Task<User?> GetByIdAsync(int id)
        => await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<User?> GetByUsernameAsync(Expression<Func<User, bool>> expression)
        => await _dbContext.Users.FirstOrDefaultAsync(expression);

    public async Task UpdateAsync(User entity)
    {
        _dbContext.Users.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}