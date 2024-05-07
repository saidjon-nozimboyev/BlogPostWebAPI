using BlogPostWebAPI.Interfaces.Common;

namespace BlogPostWebAPI.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository, IUpdatable, IChangeUserStatus
{
}
