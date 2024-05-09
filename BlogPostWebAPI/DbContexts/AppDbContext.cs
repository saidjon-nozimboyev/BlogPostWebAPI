using BlogPostWebAPI.Entities;
using BlogPostWebAPI.Enums;
using Microsoft.EntityFrameworkCore;

namespace BlogPostWebAPI.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasData(new User
            {
                Id = 1,
                FullName = "Kotta odam",
                Email = "emailemail@gmail.com",
                UserName = "adminiy",
                Biography = "men tug'ildim",
                IsVerified = true,
                Gender = Gender.Male,
                Role = Role.Admin,
                Salt = "aa27789b-72ac-444f-991f-ebd03cc0bd65",
                Password = "908ff1b8d4c1232ab41962217563de90f3d1de262d267f0d606737905443a97a",
                ImagePath = @"..\..\wwwroot\images\admin.png"
            });

        modelBuilder.Entity<User>()
            .HasIndex(p => new { p.Email, p.ImagePath, p.UserName })
            .IsUnique();
    }
}
