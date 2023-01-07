using authentication.Domain.Entities;

namespace authentication.Domain.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
