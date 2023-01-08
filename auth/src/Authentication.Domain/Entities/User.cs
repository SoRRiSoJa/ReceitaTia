namespace authentication.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }
        public string Salt { get; set; }
    }
}
