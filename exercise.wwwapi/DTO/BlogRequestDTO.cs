using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DTO
{
    public class BlogRequestDTO
    {
        public int Id { get; set; }
      

        public string Text { get; set; }
       

        public string UserId { get; set; }
        public List<CommentResponseDTO> CommentResponse { get; set; }


    }
}
