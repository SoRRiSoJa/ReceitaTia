using MediatR;
using Produto.Application.DTOs;

namespace Produto.Application.Queries.ProdutosQueries
{
    public class ObterProdutosPorMarcaQuery : IRequest<List<ProdutosDto>>
    {
        public Guid MarcaId { get; set; }
    }
}
