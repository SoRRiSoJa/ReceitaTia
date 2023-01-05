using System.Data;
using System.Data.Common;

namespace Produtos.Infra.Data
{
    public sealed class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction? Transaction { get; set; }
        public DbSession(DbConnection connection)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
