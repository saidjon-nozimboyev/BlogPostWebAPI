using BlogPostWebAPI.Common.Helpers;
using System.ComponentModel.DataAnnotations;

namespace BlogPostWebAPI.Common.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class MaxFileSize : ValidationAttribute
{
    private readonly byte _maxFileSize;

    public MaxFileSize(byte maxFileSize)
    {
        _maxFileSize = maxFileSize;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;

        if (file is not null)
        {
            var size = FileSizeHelper.ByteToMb(file.Length);
            if (size < (double)_maxFileSize)
                return ValidationResult.Success;
            else return new ValidationResult($"Image file size must be less than {_maxFileSize}");
        }
        else
            return ValidationResult.Success;
    }
}
