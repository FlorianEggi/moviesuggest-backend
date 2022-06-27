using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieSuggest.Models;
using MovieSuggest.Services;

namespace MovieSuggest.Controllers
{
    public class MovieController : Controller
    {
        private MovieApiService movieApiService;

        public MovieController(MovieApiService movieApiService)
        {
            this.movieApiService = movieApiService;
        }
        
        [HttpGet("movies/{searchterm}")]
        public async Task<List<ApiMovie>> GetMoviesAsync(string searchterm)
        {
            return await movieApiService.APIGetMoviesBySearchterm(searchterm);
        }
    }
}
