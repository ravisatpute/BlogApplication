namespace BlogApiApp.Model
{
    public class Blog
    {
        public int BlogId { get; set; }
        public int UserId { get; set; }

        public string Description { get; set; }
        public string? Content { get; set; }
        public string? Title { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? DateTime { get; set; }
    }
}
