namespace BlogPostWebAPI.Services;

public class AdminService(IUnitOfWork unitOfWork) : IAdminService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;  

    public async Task ChangeUserRoleAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user is null) 
            throw new StatusCodeException(HttpStatusCode.NotFound,"User not found");

        if (user.Role == Role.Admin)
            throw new StatusCodeException(HttpStatusCode.Unauthorized, "Dont do stupid things");

        user.Role = Role.Admin;

        await _unitOfWork.Users.UpdateAsync(user);
    }

    public async Task<IQueryable<User>> GetAllAdminAsync()
        => await _unitOfWork.Users.GetAllAsync(x => x.Role == Role.Admin);
}