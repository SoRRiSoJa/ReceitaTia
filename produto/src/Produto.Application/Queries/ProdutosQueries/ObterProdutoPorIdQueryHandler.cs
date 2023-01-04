using AutoMapper;
using MediatR;
using Produto.Application.DTOs;
using Produtos.Domain.Repositories;

namespace Produto.Application.Queries.ProdutosQueries
{
    public class ObterProdutoPorIdQueryHandler : IRequestHandler<ObterProdutoPorIdQuery, ProdutosDto>
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        public ObterProdutoPorIdQueryHandler(IMapper _mapper, IProdutoRepository _produtoRepository)
        {
            this._mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            this._produtoRepository = _produtoRepository ?? throw new ArgumentNullException(nameof(_produtoRepository));
        }
        public async Task<ProdutosDto> Handle(ObterProdutoPorIdQuery request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.Obter(request.ProdutoId);
            var produtoDto = _mapper.Map<ProdutosDto>(produto);
            return produtoDto;
        }
    }
}
