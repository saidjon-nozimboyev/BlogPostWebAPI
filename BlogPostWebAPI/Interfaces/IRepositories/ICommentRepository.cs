namespace BlogPostWebAPI.Interfaces.Repositories;

public interface ICommentRepository : ICreatable<Comment>, IDeletable<Comment>
{
    Task<IQueryable<Comment>> GetAllAsync(Expression<Func<Comment, bool>> expression);
}
