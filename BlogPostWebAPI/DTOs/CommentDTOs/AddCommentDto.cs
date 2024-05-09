namespace BlogPostWebAPI.DTOs.CommentDTOs;

public class AddCommentDto
{
    public string CommentText { get; set; } = string.Empty;

    public static implicit operator Comment(AddCommentDto dto)
    {
        return new Comment()
        {
            Body = dto.CommentText,
        };
    }
}
