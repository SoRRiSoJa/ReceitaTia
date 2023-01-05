using AutoMapper;
using FluentValidation;
using MediatR;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Repositories;

namespace Produto.Application.Commands.ProdutoCommands
{
    public class AdicionarProdutoCommandHandler : IRequestHandler<AdcionarProdutoCommand, Guid>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AdcionarProdutoCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarProdutoCommandHandler(IProdutoRepository _produtoRepository, IValidator<AdcionarProdutoCommand> _validator, IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            this._produtoRepository = _produtoRepository ?? throw new ArgumentNullException(nameof(_produtoRepository));
            this._validator = _validator ?? throw new ArgumentNullException(nameof(_validator));
            this._mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            this._unitOfWork = _unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));
        }
        public async Task<Guid> Handle(AdcionarProdutoCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var produto = _mapper.Map<Produtos.Domain.Entities.Produto>(request);
            _unitOfWork.BeginTransaction();
            var idProduto = await _produtoRepository.Inserir(produto);
            _unitOfWork.Commit();
            return idProduto;
        }
    }
}
