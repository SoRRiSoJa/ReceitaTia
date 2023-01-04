using AutoMapper;
using MediatR;
using Produto.Application.DTOs;
using Produtos.Domain.Repositories;

namespace Produto.Application.Queries.MarcaQueries
{
    internal class ObterMarcaPorIdQueryHandler : IRequestHandler<ObterMarcaPorIdQuery, MarcasDto>
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMapper _mapper;
        public ObterMarcaPorIdQueryHandler(IMarcaRepository _marcaRepository, IMapper _mapper)
        {
            this._marcaRepository = _marcaRepository ?? throw new ArgumentNullException(nameof(_marcaRepository));
            this._mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        public async Task<MarcasDto> Handle(ObterMarcaPorIdQuery request, CancellationToken cancellationToken)
        {
            var marca = await _marcaRepository.Obter(request.MarcaId);
            var marcaDto = _mapper.Map<MarcasDto>(marca);
            return marcaDto;
        }
    }
}
