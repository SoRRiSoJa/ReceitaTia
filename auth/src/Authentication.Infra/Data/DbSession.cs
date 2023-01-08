using System.Data;
using System.Data.Common;

namespace authentication.Infra.Data
{
    public sealed class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public DbSession(DbConnection connection)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
