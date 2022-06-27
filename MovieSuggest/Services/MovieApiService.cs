using MovieSuggest.Models;
using Newtonsoft.Json;

namespace MovieSuggest.Services
{
    public class MovieApiService
    {
        private static string _baseUrl = @"https://api.themoviedb.org/3/";
        private string _apiKey = "?api_key=51f3ddcab9cd18864f234b69a16ff346";
        private string _sessionId = "&guest_session_id=c00868a67576bfdad555e73754326c49";

        public async Task<List<ApiMovie>> APIGetMoviesBySearchterm(string searchterm)
        {
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
            catch (Exception ex)
            {
                throw;
            }

            return data;
        }
    }
}
