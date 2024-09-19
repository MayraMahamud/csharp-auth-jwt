using exercise.wwwapi.Configuration;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Helpers;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace exercise.wwwapi.Endpoint
{
    public static class BlogPostEndpoint
    {
        public static void ConfigureBlogPostEndpoint(this WebApplication app)
        {
           
            app.MapPost("blogpost", CreatePost);
            app.MapGet("blogposts", GetBlogPosts);
            app.MapPut("/blogpost", EditPost);  
        }
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        private static async Task<IResult> CreatePost(BlogRequestDTO request, IRepository<BlogPost> service, ClaimsPrincipal user)
        {

           

            var BlogPost = new BlogPost();

            BlogPost.Text = request.Text;

            BlogPost.UserId = user.UserRealId().ToString();

            service.Insert(BlogPost);
            service.Save();

            return Results.Ok(new Payload<string>() { data = "Created Post" });



        }



        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        private static async Task<IResult> GetBlogPosts(IRepository<BlogPost> service)
        {

            return Results.Ok(service.GetAll());

        }



        //private static async Task<IResult> GetBlogPosts2(IRepository<BlogPost> service, ICommentRepo<Comment> commentRepo)
        //{
        //    var blogPost = service.GetAll();
        //    var blogPostDTO = blogPost.Select(b => new BlogResponseDTO
        //    {
        //        Id = b.Id,
        //        Text = b.Text,
        //        UserId = b.UserId,
        //        Comments = b.Comments.Select(c => new CommentResponseDTO
        //        {
        //            CommentId = c.Id,
        //            CommentText = c.CommentText 
        //        }).ToList()
        //    }).ToList();
        //    return Results.Ok(blogPostDTO);

        //}









        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> EditPost(IRepository<BlogPost> service, int postId, BlogRequestDTO blogRequestDTO, ClaimsPrincipal user)
        {
            var existingPost = service.GetById(postId);
            if (existingPost == null)
            {
                return Results.NotFound();
            }
                
                existingPost.Text = blogRequestDTO.Text;
                service.Update(existingPost);
                service.Save(); 
                return Results.Ok(existingPost);    
        }

       
      


    }
}
    