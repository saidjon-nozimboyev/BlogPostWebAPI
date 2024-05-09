namespace BlogPostWebAPI.DTOs.UserDTOs;

public class UserDto : AddUserDto
{
    public int Id { get; set; }

    public static implicit operator UserDto(User user)
    {
        return new UserDto()
        {
            Biography = user.Biography,
            FullName = user.FullName,
            Email = user.Email,
            Gender = user.Gender,
            Id = user.Id,
            Password = user.Password,
            UserName = user.UserName,
        };
    }
}
