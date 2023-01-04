using MediatR;
using Produtos.Domain.Repositories;

namespace Produto.Application.Commands.ProdutoCommands
{
    public class AdicionarProdutoCommandHandler : IRequestHandler<AdcionarProdutoCommand, Guid>
    {
        private readonly IProdutoRepository _produtoRepository;
        public AdicionarProdutoCommandHandler(IProdutoRepository _produtoRepository)
        {
            this._produtoRepository = _produtoRepository ?? throw new ArgumentNullException(nameof(_produtoRepository));
        }
        public async Task<Guid> Handle(AdcionarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produtos.Domain.Entities.Produto()
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                CEST = request.CEST,
                NCM = request.NCM,
                QtdItensContidos = request.QtdItensContidos,
                CodigoBarras = request.CodigoBarras,
                MarcaId = request.MarcaId,
                Tipo = request.Tipo,
                UnidadeMedida = request.UnidadeMedida
            };
            var idProduto = await _produtoRepository.Inserir(produto);
            return idProduto;
        }
    }
}
