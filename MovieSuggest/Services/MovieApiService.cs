using MovieSuggest.Models;
using MovieSuggest.Models.Authentication;
using Newtonsoft.Json;

namespace MovieSuggest.Services
{
    public class MovieApiService
    {
        private static string _baseUrl = @"https://api.themoviedb.org/3/";
        private string _apiKey = "?api_key=51f3ddcab9cd18864f234b69a16ff346";

        public async Task<List<Movie>> APIGetMoviesBySearchterm(string searchterm, SessionModel sessionModel)
        {
            string _sessionId = "&guest_session_id=" + sessionModel.SessionId;
            // private string _sessionId = "&guest_session_id=c00868a67576bfdad555e73754326c49";
            string url = _baseUrl + "search/movie" + _apiKey + _sessionId + $"&query={searchterm}";
            HttpClient client = new HttpClient();
            var data = new List<ApiMovie>();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                Data responseBody = await response.Content.ReadFromJsonAsync<Data>();
                Console.WriteLine(responseBody);
                data = responseBody.results;
            }
            catch
            {
                throw;
            }
            return MapData(data);
        }

        private List<Movie> MapData(List<ApiMovie> data)
        {
            return data.Select(d => new Movie
            {
                Adult = d.adult,
                BackdropPath = d.backdrop_path,
                GenreIds = d.genre_ids,
                Id = d.id,
                OriginalLanguage = d.original_language,
                OriginalTitle = d.original_title,
                Overview = d.overview,
                Popularity = d.popularity,
                PosterPath = d.poster_path,
                ReleaseDate = d.release_date,
                Title = d.title,
                Video = d.video,
                VoteAverage = d.vote_average,
                VoteCount = d.vote_count,
            }).ToList();
        }
    }
}
