namespace BlogPostWebAPI.Interfaces.Services;

public interface IAuthManager
{
    string GenerateToken(User user);
}
