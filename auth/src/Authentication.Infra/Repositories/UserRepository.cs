using authentication.Domain.Entities;
using authentication.Domain.Repositories;
using authentication.Infra.Data;
using Dapper;
using System.Text.RegularExpressions;

namespace authentication.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSession _session;
        public UserRepository(DbSession session)
        {
            this._session= _session ?? throw new ArgumentNullException(nameof(_session));
        }
        public Task<Guid> Add(User user)
        {
            throw new NotImplementedException();
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
            var query = @"SELECT * FROM user u WHERE u.login = @login";
            var result = await _session.Connection.QueryFirstOrDefaultAsync<User>(query, new { id });
            return result;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var query = @"SELECT * FROM user";
            var result = await _session.Connection.QueryAsync<User>(query);
            return result;
        }

        public async Task<User> GetByLogin(string login)
        {
            var query = @"SELECT * FROM user u WHERE u.login = @login";
            var result = await _session.Connection.QueryFirstOrDefaultAsync<User>(query, new { login });
            return result;
        }
    }
}
