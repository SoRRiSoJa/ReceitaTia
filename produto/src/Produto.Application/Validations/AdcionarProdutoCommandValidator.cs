using FluentValidation;
using Produto.Application.Commands.ProdutoCommands;

namespace Produto.Application.Validations
{
    public class AdcionarProdutoCommandValidator : AbstractValidator<AdcionarProdutoCommand>
    {
        public AdcionarProdutoCommandValidator()
        {
            RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do produto é obrigatório")
            .Length(2, 100).WithMessage("O nome do produto deve ter entre 2 e 100 caracteres");

            RuleFor(x => x.Descricao)
            .NotEmpty().WithMessage("A descriçaõ do produto é obrigatória")
            .Length(2, 100).WithMessage("O nome do produto deve ter entre 2 e 100 caracteres");
        }
    }
}
