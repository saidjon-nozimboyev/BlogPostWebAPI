namespace BlogPostWebAPI.Interfaces.Services;

public interface IFileService
{
    Task<string> SaveImageAsync(IFormFile image);
}
