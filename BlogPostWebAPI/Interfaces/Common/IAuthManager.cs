using BlogPostWebAPI.Entities;

namespace BlogPostWebAPI.Interfaces.Common;

public interface IAuthManager
{
    string GeneratedToken(User user);
}
