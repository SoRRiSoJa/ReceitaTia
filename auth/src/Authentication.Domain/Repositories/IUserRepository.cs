using authentication.Domain.Entities;

namespace authentication.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<Guid> Add(User user);
        public Task<bool> Edit(User user);
        public Task<bool> Delete(Guid idUser);
        public Task<User> Get(Guid id);
        public Task<User> GetByLogin(string login);
        public Task<IEnumerable<User>> GetAll();
    }
}
