using AutoMapper;
using MediatR;
using Produto.Application.DTOs;
using Produtos.Domain.Repositories;

namespace Produto.Application.Queries.MarcaQueries
{
    public class ObterTodasAsMarcasQueryHandler : IRequestHandler<ObterTodasAsMarcasQuery, List<MarcasDto>>
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMapper _mapper;
        public ObterTodasAsMarcasQueryHandler(IMarcaRepository _marcaRepository, IMapper _mapper)
        {
            this._marcaRepository = _marcaRepository ?? throw new ArgumentNullException(nameof(_marcaRepository));
            this._mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        public async Task<List<MarcasDto>> Handle(ObterTodasAsMarcasQuery request, CancellationToken cancellationToken)
        {
            var marcas = await _marcaRepository.ObterTodos();
            var marcasDto = _mapper.Map<List<MarcasDto>>(marcas);
            return marcasDto;
        }
    }
}
