using exercise.wwwapi.DTO;
using exercise.wwwapi.Helpers;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace exercise.wwwapi.Endpoint
{
    public static class UserFollowEndpoint
    {
        public static void ConfigureUserFollowEndpoint(this WebApplication app)
        {
            app.MapPost("followUser/{followeid}", FollowUser);

            app.MapGet("follows", ViewAll);

        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        private static async Task<IResult> FollowUser(IRepository<Follows> service, int followeeId, ClaimsPrincipal user)
        {
           
                 Follows followe = new Follows();
                followe.FollowerId = user.UserRealId().Value;
            followe.FollowsId = followeeId;
            service.Insert(followe);
            service.Save();  
            return Results.Ok();

        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        private static async Task<IResult> ViewAll(IRepository<Follows> service, IRepository<BlogPost> repository, ClaimsPrincipal user)
        {
            var result = service.GetAll();
            List<object> results = new List<object>();
            foreach (var item in result.Where(f => f.FollowerId == user.UserRealId().Value))
            {
                var posts = repository.GetAll().ToList().Where(p => p.UserId == item.FollowsId.ToString()).ToList();
                foreach (var post in posts)
                {
                    results.Add(new { Text = post.Text });
                }

            }
            return Results.Ok(results);

        }

    }
}
