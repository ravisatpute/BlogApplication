using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApiApp.Model
{
    public class BlogMap
    {
        public BlogMap(EntityTypeBuilder<Blog> entityBuilder)
        {
            entityBuilder.HasKey(t => t.BlogId);
            entityBuilder.Property(t => t.UserId);
            entityBuilder.Property(t => t.Description).IsRequired();
            entityBuilder.Property(t => t.Title);
            entityBuilder.Property(t => t.DateTime);
           

        }
    }
}
