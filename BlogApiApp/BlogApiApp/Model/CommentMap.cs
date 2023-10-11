using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApiApp.Model
{
    public class CommentMap
    {
        public CommentMap(EntityTypeBuilder<Comment> entityBuilder)
        {
            entityBuilder.HasKey(t => t.CommentId);
            entityBuilder.Property(t => t.BlogId).IsRequired();
            entityBuilder.Property(t => t.UserId);
            entityBuilder.Property(t => t.UserName);

            entityBuilder.Property(t => t.Description).IsRequired();
            entityBuilder.Property(t => t.DateTime).IsRequired();
            
    }
    }
}
