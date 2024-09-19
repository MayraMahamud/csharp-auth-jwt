using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.Models
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("username")]

        public required string Username { get; set; }
        [Column("password")]

        public required string PasswordHash { get; set; } 
    }
}
