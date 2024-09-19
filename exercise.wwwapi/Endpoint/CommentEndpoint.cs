using exercise.wwwapi.DTO;
using exercise.wwwapi.Helpers;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace exercise.wwwapi.Endpoint
{
    public static class CommentEndpoint
    {
        public static void ConfigureCommentEndpoint(this WebApplication app)
        {
            app.MapPost("comment", AddComment);

            app.MapGet("comment", GetAllComments);

        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> AddComment(CommentRequestDTO request, ICommentRepo<Comment> service,  int postId)
        {
            


            var comment = new Comment
            {
                Text = request.Text,
                UserId = request.UserId,
                BlogPostId = postId
            };
            service.Insert(comment);
            service.Save();
            return Results.Ok(new Payload<string>() { data = "Comment added" });

        }




        private static async Task<IResult> GetAllComments(ICommentRepo<Comment> service)
        {
            var comments = service.GetAllComments();
            if(comments == null)
            {
                return Results.NotFound();
            }
            List<Object> result = new List<Object>();
            foreach (var comment in comments)
            {
                result.Add(new { text = comment.Text, UserId = comment.UserId });

            }
            
            return Results.Ok(result);
        }


    }
}
