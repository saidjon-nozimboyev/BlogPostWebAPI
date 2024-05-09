namespace BlogPostWebAPI.Interfaces.Common;

public interface ICreatable<T>
{
    Task CreateAsync(T entity);
}
