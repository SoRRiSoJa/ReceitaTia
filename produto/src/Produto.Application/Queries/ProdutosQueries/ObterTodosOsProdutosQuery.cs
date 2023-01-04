using MediatR;
using Produto.Application.DTOs;

namespace Produto.Application.Queries.ProdutosQueries
{
    public class ObterTodosOsProdutosQuery : IRequest<List<ProdutosDto>>
    {
    }
}
