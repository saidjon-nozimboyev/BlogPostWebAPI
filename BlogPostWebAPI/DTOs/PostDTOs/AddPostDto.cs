namespace BlogPostWebAPI.DTOs.PostDTOs;

public class AddPostDto
{
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;

    public static implicit operator Post(AddPostDto dto)
    {
        return new Post()
        {
            Title = dto.Title,
            Body = dto.Body,
        };
    }
}
