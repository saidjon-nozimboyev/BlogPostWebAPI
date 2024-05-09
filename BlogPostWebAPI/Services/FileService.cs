namespace BlogPostWebAPI.Services;

public class FileService : IFileService
{
    private const string _folderName = "images";
    private readonly string _basePath;

    public FileService(IWebHostEnvironment environment)
    {
        _basePath = environment.WebRootPath;

        if (!Directory.Exists(_basePath))
            Directory.CreateDirectory(_basePath);

        if (!Directory.Exists(Path.Combine(_basePath, _folderName)))
            Directory.CreateDirectory(Path.Combine(_basePath, _folderName));
    }
    public async Task<string> SaveImageAsync(IFormFile image)
    {
        var fileName = image.FileName.CreateNameForFile();
        var partPath = Path.Combine(_folderName, fileName);
        var path = Path.Combine(_basePath, partPath);

        var stream = File.Create(path);
        await image.CopyToAsync(stream);
        stream.Close();

        return path;
    }
}
