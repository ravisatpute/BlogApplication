using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogApiApp.Model
{
    [Bind(include: "CommentId,BlogId,UserId,Description,DateTime")]
    public class Comment
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        [BindNever]
        [JsonIgnore]
        [NotMapped]
      
        public string? UserName { get; set; }
        public string Description { get; set; }
        //public string Title { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
