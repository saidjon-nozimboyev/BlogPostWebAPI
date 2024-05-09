using BlogPostWebAPI.DbContexts;
using BlogPostWebAPI.Entities;
using BlogPostWebAPI.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogPostWebAPI.Repositories;
#pragma warning disable
public class PostRepository(AppDbContext dbContext) : IPostRepository
{
    private readonly AppDbContext _dbContext = dbContext;   

    public async Task CreateAsync(Post entity)
    {
        await _dbContext.Posts.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IQueryable<Post>> GetAllAsync(Expression<Func<Post, bool>> expression)
        => _dbContext.Posts.Where(expression);

    public async Task<Post?> GetByIdAsync(int id)
        => await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IQueryable<Post>> GetByNameAsync(Expression<Func<Post, bool>> expression)
        => _dbContext.Posts.Where(expression);

    public async Task UpdateAsync(Post entity)
    {
        _dbContext.Posts.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
