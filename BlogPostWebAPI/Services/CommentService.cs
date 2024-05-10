using BlogPostWebAPI.DTOs.CommentDTOs;

namespace BlogPostWebAPI.Services;

public class CommentService(IUnitOfWork unitOfWork) : ICommentService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;  

    public async Task CreateAsync(AddCommentDto dto)
    {
        if (dto is null)
            throw new StatusCodeException(HttpStatusCode.Conflict,"Comment can't be empty");

        await _unitOfWork.Comments.CreateAsync(dto);
    }

    public async Task DeleteAsync(int id)
    {
        var comment = await _unitOfWork.Comments.GetAllAsync(x => x.Id == id);
        if (comment is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Comment not found");
    }

    public async Task<IQueryable<CommentDto>> GetAllAsync()
    {
        var comments = await _unitOfWork.Comments.GetAllAsync(x => x.Body != null);
        return comments.Select(x=>(CommentDto)x);
    }

    public async Task<CommentDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(CommentDto dto)
    {
        var comment = await _unitOfWork.Comments.GetAllAsync(x => x.Id==dto.Id);
        if (comment is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Comment nnot found");

        await _unitOfWork.Comments.
    }
}
