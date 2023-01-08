using authentication.Domain.Entities;
using authentication.Domain.Repositories;
using authentication.Infra.Data;
using Dapper;

namespace authentication.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSession _session;
        public UserRepository(DbSession _session)
        {
            this._session = _session ?? throw new ArgumentNullException(nameof(_session));
        }
        public async Task<Guid> Add(User user)
        {
            var query = @"INSERT INTO public.users (userid, username, login, userpassword, userrole, creationdate, deleted, salt) VALUES(@userid, @username, @login, @userpassword, @userrole, @creationdate, @deleted, @salt);";
            var userId = Guid.NewGuid();
            var rows = await _session.Connection.ExecuteAsync(query, new { UserId = userId, user.Username, user.Login, userpassword=user.Password, userrole=user.Role, creationdate=DateTime.Now, Deleted = false, user.Salt });
            return rows > 0 ? userId : Guid.Empty;
        }

        public Task<bool> Delete(Guid idUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(Guid id)
        {
            var query = @"SELECT * FROM users u WHERE u.userid = @id";
            var result = await _session.Connection.QueryFirstOrDefaultAsync<User>(query, new { id });
            return result;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var query = @"SELECT * FROM users";
            var result = await _session.Connection.QueryAsync<User>(query);
            return result;
        }

        public async Task<User> GetByLogin(string login)
        {
            var query = @"SELECT * FROM users u WHERE u.userlogin = @login";
            var result = await _session.Connection.QueryFirstOrDefaultAsync<User>(query, new { login });
            return result;
        }
    }
}
