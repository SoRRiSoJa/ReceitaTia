using MediatR;
using Produto.Application.DTOs;

namespace Produto.Application.Queries.ProdutosQueries
{
    public class ObterProdutoPorIdQuery : IRequest<ProdutosDto>
    {
        public Guid ProdutoId { get; set; }
    }
}
