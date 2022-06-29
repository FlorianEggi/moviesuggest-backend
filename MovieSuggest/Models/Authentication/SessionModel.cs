namespace MovieSuggest.Models.Authentication
{
    public class SessionModel
    {
        public int UserId { get; set; }
        public string SessionId { get; set; }
        public string ExpireDate { get; set; }
    }
}
