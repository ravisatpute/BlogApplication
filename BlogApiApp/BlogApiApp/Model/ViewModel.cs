using System.ComponentModel.Design;

namespace BlogApiApp.Model
{
    public class ViewModel
    {
        //public int Id { get; set; }
        //public int BlogId { get; set; } u.UserId,c.CommentId,u.UserName,
        // c.Description as comment,c.DateTime as commentTime 
        public int? UserId { get; set; }
        public int? CommentId { get; set; }
        public string? UserName { get; set; }
        public int BlogId { get; set; }
        public string? comment { get; set; }
        //public string Title { get; set; }
     //   public string? Comment { get; set; }
        public DateTime? commentTime { get; set; }
       // public DateTime? BlogTime { get;}
    }
}
