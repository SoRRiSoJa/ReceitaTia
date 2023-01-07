using authentication.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace authentication.Infra.Mappers
{
    public class UserMap : DommelEntityMap<User>
    {
        public UserMap()
        {
            ToTable("users");
            Map((user) => (user).UserId).ToColumn("id").IsKey().IsKey();
            Map((user) => (user).Username).ToColumn("id").IsKey().IsKey();
            Map((user) => (user).Password).ToColumn("id").IsKey().IsKey();
            Map((user) => (user).UserId).ToColumn("id").IsKey().IsKey();
        }
    }
}
