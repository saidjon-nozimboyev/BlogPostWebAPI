using BlogPostWebAPI.Entities;
using BlogPostWebAPI.Interfaces.Common;
using System.Linq.Expressions;

namespace BlogPostWebAPI.Interfaces.Repositories;

public interface ICommentRepository : ICreatable<Comment>, IDeletable<Comment>
{
    Task<IQueryable<Comment>> GetAllAsync(Expression<Func<Comment,bool>> expression);
}
