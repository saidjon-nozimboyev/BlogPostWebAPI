namespace BlogPostWebAPI.Interfaces.IServices;

public interface IAdminService
{
    Task<IQueryable<User>> GetAllAdminAsync();
    Task ChangeUserRoleAsync(int id);
}