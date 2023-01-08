namespace authentication.Application.DTOs
{
    public class UsersDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Salt { get; set; }
    }
}
