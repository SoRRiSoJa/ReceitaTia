using authentication.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;

namespace authentication.Infra.Mappers
{
    public class UserMap : DommelEntityMap<User>
    {
        public UserMap()
        {
            ToTable("users");
            Map((user) => (user).UserId).ToColumn("userid").IsKey();
            Map((user) => (user).Username).ToColumn("username");
            Map((user) => (user).Login).ToColumn("login");
            Map((user) => (user).Password).ToColumn("userpassword");
            Map((user) => (user).Role).ToColumn("userrole");
            Map((user) => (user).CreationDate).ToColumn("creationdate");
            Map((user) => (user).Deleted).ToColumn("deleted");
            Map((user) => (user).Salt).ToColumn("salt");
        }
    }
}
