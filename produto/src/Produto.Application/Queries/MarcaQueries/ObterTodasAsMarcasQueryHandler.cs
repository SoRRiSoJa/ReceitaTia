using MediatR;
using Produto.Application.DTOs;
using Produtos.Domain.Repositories;

namespace Produto.Application.Queries.MarcaQueries
{
    public class ObterTodasAsMarcasQueryHandler : IRequestHandler<ObterTodasAsMarcasQuery, List<MarcasDto>>
    {
        private readonly IMarcaRepository _marcaRepository;
        public ObterTodasAsMarcasQueryHandler(IMarcaRepository _marcaRepository)
        {
            this._marcaRepository = _marcaRepository ?? throw new ArgumentNullException(nameof(_marcaRepository));
        }
        public async Task<List<MarcasDto>> Handle(ObterTodasAsMarcasQuery request, CancellationToken cancellationToken)
        {
            var marcas = await _marcaRepository.ObterTodos();
            return marcas.Select(m => new MarcasDto() {MarcaId=m.MarcaId,Nome=m.Nome }).ToList();
        }
    }
}
