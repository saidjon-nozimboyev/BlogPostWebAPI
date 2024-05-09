namespace BlogPostWebAPI.Interfaces.Repositories;

public interface IUnitOfWork
{
    IPostRepository Posts { get; }
    ICommentRepository Comments { get; }
    IUserRepository Users { get; }
}
