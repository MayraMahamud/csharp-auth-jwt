using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.Models
{
    [Table("blogpost")]
    public class BlogPost
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("text")]

        public string Text { get; set; }
        [Column("authorid")]

        public string UserId { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
        
    }
}
