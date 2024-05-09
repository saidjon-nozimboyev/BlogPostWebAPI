using BlogPostWebAPI.Entities;
using BlogPostWebAPI.Interfaces.Common;
using System.Linq.Expressions;

namespace BlogPostWebAPI.Interfaces.Repositories;

public interface IPostRepository : ICreatable<Post> ,IUpdatable<Post>, IReadable<Post>
{
    Task<IQueryable<Post>> GetByNameAsync(Expression<Func<Post,bool>> expression);  
}
