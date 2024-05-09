namespace BlogPostWebAPI.DTOs.UserDTOs;

public class AddUserDto
{
    [Required(ErrorMessage = "User name is required")]
    [Length(3, 30, ErrorMessage = "")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "User email is required"), EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Gender is required")]
    public Gender Gender { get; set; }

    [MaxLength(70, ErrorMessage = "")]
    public string Biography { get; set; } = string.Empty;

    [Length(5, 32, ErrorMessage = "Username must be between 5 and 32 characters")]
    public string UserName { get; set; } = string.Empty;

    [Required, Password]
    public string Password { get; set; } = string.Empty;

    [AllowedFileExtensions([".jpg", ".png", ".jpeg"])]
    [MaxFileSize(10)]
    public IFormFile? Image { get; set; }


    public static implicit operator User(AddUserDto dto)
    {
        return new User
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Gender = dto.Gender,
            Biography = dto.Biography,
            UserName = dto.UserName,
            Password = dto.Password
        };
    }
}
