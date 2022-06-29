using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieSuggest.Models;
using MovieSuggest.Models.Authentication;
using MovieSuggest.Services;

namespace MovieSuggest.Controllers
{
    public class MovieController : Controller
    {
        private MovieApiService movieApiService;
        private AuthService authService;

        public MovieController(MovieApiService movieApiService, AuthService authService)
        {
            this.movieApiService = movieApiService;
            this.authService = authService;
        }
        
        [HttpPost("movies")]
        public async Task<List<Movie>> GetMoviesAsync([FromQuery] string searchterm, [FromBody] SessionModel sessionModel)
        {
            return await movieApiService.APIGetMoviesBySearchterm(searchterm, sessionModel);
        }

        [HttpGet("session")]
        public async Task<SessionModel> GetSession([FromQuery] int userId)
        {
            return await authService.CreateSession(userId);
        }
    }
}
