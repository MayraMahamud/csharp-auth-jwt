using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.Models
{
    [Table("comment")]
    public class Comment
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("text")]

        public string Text { get; set; }
        [Column("userid")]

        public string UserId { get; set; }
        [Column("blogpostid")]

        [ForeignKey("BlogPostId")]
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }


    }
}
