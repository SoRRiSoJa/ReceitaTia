using AutoMapper;
using FluentValidation;
using MediatR;
using Produto.Application.Commands.Marca;
using Produtos.Domain.Repositories;

namespace Produto.Application.Commands.ProdutoCommands
{
    public class AdicionarProdutoCommandHandler : IRequestHandler<AdcionarProdutoCommand, Guid>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AdcionarProdutoCommand> _validator;
        public AdicionarProdutoCommandHandler(IProdutoRepository _produtoRepository, IValidator<AdcionarProdutoCommand> _validator, IMapper _mapper)
        {
            this._produtoRepository = _produtoRepository ?? throw new ArgumentNullException(nameof(_produtoRepository));
            this._validator = _validator ?? throw new ArgumentNullException(nameof(_validator));
            this._mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        public async Task<Guid> Handle(AdcionarProdutoCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var produto = _mapper.Map<Produtos.Domain.Entities.Produto>(request);
            var idProduto= await _produtoRepository.Inserir(produto);
            return idProduto;
        }
    }
}
