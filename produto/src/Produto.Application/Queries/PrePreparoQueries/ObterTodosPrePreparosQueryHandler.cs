using AutoMapper;
using MediatR;
using Produto.Application.DTOs;
using Produtos.Domain.Repositories;

namespace Produto.Application.Queries.PrePreparoQueries
{
    public class ObterTodosPrePreparosQueryHandler : IRequestHandler<ObterTodosPrePreparosQuery, List<PrePreparosDto>>
    {
        private readonly IPrePreparoRepository _prePreparoRepository;
        private readonly IMapper _mapper;
        public ObterTodosPrePreparosQueryHandler(IPrePreparoRepository _prePreparoRepository, IMapper _mapper)
        {
            this._prePreparoRepository = _prePreparoRepository ?? throw new ArgumentNullException(nameof(_prePreparoRepository));
            this._mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        public async Task<List<PrePreparosDto>> Handle(ObterTodosPrePreparosQuery request, CancellationToken cancellationToken)
        {
            var prePreparos = await _prePreparoRepository.ObterTodos();
            var prePreparosDto = _mapper.Map<List<PrePreparosDto>>(prePreparos);
            return prePreparosDto;
        }
    }
}
