using MediatR;
using Produto.Application.DTOs;
using Produtos.Domain.Repositories;

namespace Produto.Application.Queries.MarcaQueries
{
    internal class ObterMarcaPorIdQueryHandler : IRequestHandler<ObterMarcaPorIdQuery, MarcasDto>
    {
        private readonly IMarcaRepository _marcaRepository;
        public ObterMarcaPorIdQueryHandler(IMarcaRepository _marcaRepository)
        {
            this._marcaRepository = _marcaRepository ?? throw new ArgumentNullException(nameof(_marcaRepository));
        }
        public async Task<MarcasDto> Handle(ObterMarcaPorIdQuery request, CancellationToken cancellationToken)
        {
            var marca = await _marcaRepository.Obter(request.MarcaId);
            return new MarcasDto() { MarcaId = marca.MarcaId, Nome = marca.Nome };
        }
    }
}
