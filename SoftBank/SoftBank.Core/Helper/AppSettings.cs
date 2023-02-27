namespace SoftBank.Core
{
    public class AppSettings
    {
        public string? Secret { get; set; }
        public string? ValidAudience { get; set; }
        public string? ValidIssuer { get; set; }
        public int TokenValidityInMinutes { get; set; }
        public int RefreshTokenValidityInDays { get; set; } 
    }
}
