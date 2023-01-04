using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Produtos.Infra.Data
{
    public sealed class DbSession : IDisposable
    {
        private readonly Guid _id = Guid.NewGuid();
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        private readonly IConfiguration _configuracoes;
        public DbSession(IConfiguration _configuracoes)
        {
            this._configuracoes = _configuracoes ?? throw new ArgumentNullException(nameof(_configuracoes));
            Connection = new NpgsqlConnection(_configuracoes.GetConnectionString("Receita"));    
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
