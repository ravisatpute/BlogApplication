using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApiApp.Model
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.UserId);
            entityBuilder.Property(t => t.UserName).IsRequired();
            entityBuilder.Property(t => t.Address);
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.Password).IsRequired();
            entityBuilder.Property(t => t.DateTime);

        }
    }
}
