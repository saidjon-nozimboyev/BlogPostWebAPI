using BlogPostWebAPI.DTOs;

namespace BlogPostWebAPI.Interfaces.Services;

public interface IAccountService
{
    Task RegisterAsync(AddUserDto dto); 
    Task<string> LoginAsync(LoginDto login);
    Task SendCodeAsync(string email);
    Task CheckCodeAsync(string email, string code);
    Task UpdatePasswordAsync(string email, string newPassword);
}