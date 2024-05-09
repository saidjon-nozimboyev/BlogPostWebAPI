namespace BlogPostWebAPI.Entities;

public sealed class User : Base
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public Role Role { get; set; } = Role.User;
    public bool IsVerified { get; set; } = false;
    public string Biography { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
}