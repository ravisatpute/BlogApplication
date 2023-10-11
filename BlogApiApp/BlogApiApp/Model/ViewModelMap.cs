using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApiApp.Model
{
    public class ViewModelMap
    {
        public ViewModelMap(EntityTypeBuilder<ViewModel> entityBuilder)
        {
            //entityBuilder.HasKey(t => t.BlogId);
           // entityBuilder.Property(t => t.Id).IsRequired();
            entityBuilder.Property(t => t.UserId).IsRequired();
            entityBuilder.HasKey(t => t.CommentId);  
          //  entityBuilder.Property(t => t.Title);
            entityBuilder.Property(t => t.comment);
          //  entityBuilder.Property(t => t.Comments);
            //entityBuilder.Property(t => t.BlogTime);
            entityBuilder.Property(t => t.commentTime);
        }
    }
}
