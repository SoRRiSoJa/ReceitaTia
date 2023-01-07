using MediatR;
using Produto.Application.DTOs;

namespace Produto.Application.Queries.PrePreparoQueries
{
    public class ObterTodosPrePreparosQuery : IRequest<List<PrePreparosDto>>
    {
    }
}
