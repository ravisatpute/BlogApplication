using BlogApiApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BlogApiApp.Services
{
    public class BlogDataContext : DbContext
    {
        public BlogDataContext(DbContextOptions<BlogDataContext> options) : base(options)
        {

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ViewModelMap(modelBuilder.Entity<ViewModel>());
            new UserMap(modelBuilder.Entity<User>());
            new BlogMap(modelBuilder.Entity<Blog>());
            new CommentMap(modelBuilder.Entity<Comment>());
            modelBuilder.Entity<Comment>().Ignore(p => p.UserName);


        }
    }
}