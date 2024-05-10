using BlogPostWebAPI.DTOs.CommentDTOs;

namespace BlogPostWebAPI.Interfaces.IServices;

public interface ICommentService
{
    Task CreateAsync(AddCommentDto dto);
    Task<IQueryable<CommentDto>> GetAllAsync();
    Task<CommentDto> GetByIdAsync(int id);
    Task UpdateAsync(CommentDto dto);
    Task DeleteAsync(int id);
}