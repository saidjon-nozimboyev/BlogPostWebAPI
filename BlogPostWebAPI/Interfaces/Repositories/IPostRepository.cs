using BlogPostWebAPI.Interfaces.Common;

namespace BlogPostWebAPI.Interfaces.Repositories;

public interface IPostRepository : IGenericRepository, IUpdatable, IChangeUserStatus
{
}
