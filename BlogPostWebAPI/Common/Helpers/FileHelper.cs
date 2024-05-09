namespace BlogPostWebAPI.Common.Helpers;

public static class FileHelper
{
    public static string CreateNameForFile(this string fileName)
        => $"img_{Guid.NewGuid()}_{fileName}";

    public static string GetDefaultImagePath()
        => @"../../wwwroot/images/admin.jpg";
}
