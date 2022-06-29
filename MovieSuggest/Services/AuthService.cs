using MovieSuggest.Models.Authentication;
using MovieSuggest.Models.MovieApiModels;

namespace MovieSuggest.Services
{
    public class AuthService
    {
        private string _apiKey = "?api_key=51f3ddcab9cd18864f234b69a16ff346";
        private static string _baseUrl = @"https://api.themoviedb.org/3/";
        public async Task<SessionModel> CreateSession(int userId)
        {
            //https://api.themoviedb.org/3/authentication/guest_session/new?api_key=51f3ddcab9cd18864f234b69a16ff346
            var session = new SessionModel();
            string url = _baseUrl + "authentication/guest_session/new" + _apiKey;
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                SessionModelData responseBody = await response.Content.ReadFromJsonAsync<SessionModelData>();
                session = MapData(responseBody, userId);
            }
            catch
            {
                throw;
            }
            return session;
        }

        private SessionModel MapData(SessionModelData? res, int userId)
        {
            return new SessionModel { 
                SessionId = res.guest_session_id, 
                ExpireDate = res.expires_at, 
                UserId = userId, 
            };
        }
    }
}
