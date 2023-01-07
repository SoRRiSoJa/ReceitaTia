using System.Data.Common;
using System.Data;

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
