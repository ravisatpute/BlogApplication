using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogApiApp.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [PasswordPropertyText]
        public string? Password { get; set; }
        public string? Address { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
