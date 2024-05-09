namespace BlogPostWebAPI.Interfaces.Services;

public interface IEmailService
{
    Task SendMessageToEmailAsync(string to, string title, string body);
}
