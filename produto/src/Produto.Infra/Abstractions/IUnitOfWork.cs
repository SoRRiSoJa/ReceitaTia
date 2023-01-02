namespace Produtos.Infra.Abstractions
{
    internal interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
