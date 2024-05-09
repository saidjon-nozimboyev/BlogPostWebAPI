namespace BlogPostWebAPI.DTOs.UserDTOs;

public class UpdateUserDto
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string Biography { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public static implicit operator User(UpdateUserDto dto)
    {
        return new User()
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Gender = dto.Gender,
            Biography = dto.Biography,
            UserName = dto.UserName,
        };
    }
}
