using BlogPostWebAPI.Common.Exceptions;
using BlogPostWebAPI.Common.Helpers;
using BlogPostWebAPI.Common.Security;
using BlogPostWebAPI.DTOs;
using BlogPostWebAPI.Entities;
using BlogPostWebAPI.Interfaces.Repositories;
using BlogPostWebAPI.Interfaces.Services;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace BlogPostWebAPI.Services;

public class AccountService(IUnitOfWork unitOfWork,
                            IFileService fileService,
                            IEmailService emailService,
                            IMemoryCache memoryCache,
                            IAuthManager authManager) 
    : IAccountService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;  
    private readonly IFileService _fileService = fileService;
    private readonly IEmailService _emailService = emailService;
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly IAuthManager _authManager = authManager;   

    public Task CheckCodeAsync(string email, string code)
    {
        throw new NotImplementedException();
    }

    public async Task<string> LoginAsync(LoginDto login)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(x => x.Email == login.Email);

        if (user is null)
            throw new StatusCodeException(HttpStatusCode.Conflict, "User with this email doesn't exist");
        if (!user.IsVerified)
            throw new StatusCodeException(HttpStatusCode.Conflict, "Unauthorized action");
        if (!PasswordHasher.IsEqual(user.Password, login.Password, user.Salt))
            throw new StatusCodeException(HttpStatusCode.Conflict, "Password is incorrect");

        return _authManager.GenerateToken(user);
    }

    public async Task RegisterAsync(AddUserDto dto)
    {
        var model = await _unitOfWork.Users.GetByEmailAsync(x => x.Email == dto.Email);
        if (model is not null)
            throw new StatusCodeException(HttpStatusCode.Conflict,"User with this email already exists!");
        
        var user = (User)dto;   
        if (dto.Image is null)
            user.ImagePath = FileHelper.GetDefaultImagePath();
        else
            user.ImagePath = await _fileService.SaveImageAsync(dto.Image);

        var result = PasswordHasher.GetHash(dto.Password, out var salt);
        user.Password = result;
        user.Salt = salt;
        await _unitOfWork.Users.CreateAsync(user);
    }

    public async Task SendCodeAsync(string email)
    {
        var user = _unitOfWork.Users.GetByEmailAsync(x => x.Email == email);
        if (user is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "User with this email not found");

        var code = GenerateCode();
        _memoryCache.Set(email, code, TimeSpan.FromSeconds(60));

        await _emailService.SendMessageToEmailAsync(email, "Verification code", code);
    }

    public async Task UpdatePasswordAsync(string email, string newPassword)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(x => x.Email == email);
        if (user is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "User with this email not found");

        if (newPassword is null)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Password is required");

        user.Password = PasswordHasher.GetHash(newPassword, out var salt);
        await _unitOfWork.Users.UpdateAsync(user);
    }
    private string GenerateCode()
    {
        return new Random().Next(9999, 100000).ToString();
    }
}
