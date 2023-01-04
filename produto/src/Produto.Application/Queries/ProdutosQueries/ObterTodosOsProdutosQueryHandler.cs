using AutoMapper;
using MediatR;
using Produto.Application.DTOs;
using Produtos.Domain.Repositories;

namespace Produto.Application.Queries.ProdutosQueries
{
    public class ObterTodosOsProdutosQueryHandler : IRequestHandler<ObterTodosOsProdutosQuery, List<ProdutosDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        public ObterTodosOsProdutosQueryHandler(IMapper _mapper, IProdutoRepository _produtoRepository)
        {
            this._mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            this._produtoRepository = _produtoRepository ?? throw new ArgumentNullException(nameof(_produtoRepository));
        }
        public async Task<List<ProdutosDto>> Handle(ObterTodosOsProdutosQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _produtoRepository.ObterTodos(null);
            var produtosDto = _mapper.Map<List<ProdutosDto>>(produtos);
            return produtosDto;
        }
    }
}
