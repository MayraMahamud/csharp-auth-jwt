using exercise.wwwapi.Models;

namespace exercise.wwwapi.DTO
{
    public class BlogResponseDTO
    {
        public int Id { get; set; }


        public string Text { get; set; }


        public string UserId { get; set; }
        public List<CommentResponseDTO> CommentResponse { get; set; }
        //public List<Comment> Comments { get; set; }
    }
}
