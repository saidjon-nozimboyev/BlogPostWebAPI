namespace BlogPostWebAPI.DTOs.PostDTOs;

public class PostDto : AddPostDto
{
    public int Id { get; set; }
    public List<string> ImageUrls { get; set; } = new();
    public int ViewsCount { get; set; }
    public int[] LikesCount { get; set; } = null!;

    public static implicit operator PostDto(Post post)
    {
        return new PostDto()
        {
            Body = post.Body,
            Id = post.Id,
            ImageUrls = post.ImagesPath!,
            LikesCount = post.Likes,
            Title = post.Title,
            ViewsCount = post.Views,
        };
    }
}
