namespace MovieSuggest.Models.MovieApiModels
{
    public class SessionModelData
    {
        public bool success { get; set; }
        public string guest_session_id { get; set; }
        public string expires_at { get; set; }
    }
}
