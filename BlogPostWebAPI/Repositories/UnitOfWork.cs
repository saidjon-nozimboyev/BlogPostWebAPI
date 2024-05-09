using BlogPostWebAPI.DbContexts;
using BlogPostWebAPI.Interfaces.Repositories;

namespace BlogPostWebAPI.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    public IPostRepository Posts => new PostRepository(_dbContext);

    public ICommentRepository Comments =>new CommentRepository(_dbContext);

    public IUserRepository Users => new UserRepository(_dbContext);
}
