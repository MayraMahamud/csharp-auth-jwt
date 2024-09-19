using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.Models
{
    public class Follows
    {
        public int Id  { get; set; }
        
        public int FollowerId { get; set; }
        public int FollowsId { get; set; }

    }
}
