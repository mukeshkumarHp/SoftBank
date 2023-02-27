namespace SoftBank.Core
{

    public class AuthenticateResponse
    {
        public int UserID { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ProfileImage { get; set; }
        public int RoleID { get; set; }
        public int DesignationID { get; set; }
        public string? Token { get; set; }
        public string? RefereshToken { get; set; }
        public string? Message { get; set; }
    }
}