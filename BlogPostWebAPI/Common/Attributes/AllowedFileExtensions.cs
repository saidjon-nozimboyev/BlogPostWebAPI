namespace BlogPostWebAPI.Common.Attributes;


[AttributeUsage(AttributeTargets.Property)]
public class AllowedFileExtensions : ValidationAttribute
{
    private readonly string[] _extensions;
    public AllowedFileExtensions(string[] extensions)
    {
        _extensions = extensions;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;

        if (file is not null)
        {
            var extension = Path.GetExtension(file.FileName);

            if (_extensions.Contains(extension))
                return ValidationResult.Success;
            else
                return new ValidationResult("The format of file is invalid");
        }
        else
            return ValidationResult.Success;
    }
}
