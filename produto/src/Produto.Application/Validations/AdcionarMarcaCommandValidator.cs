using FluentValidation;
using Produto.Application.Commands.Marca;

namespace Produto.Application.Validations
{
    public class AdcionarMarcaCommandValidator : AbstractValidator<AdcionarMarcaCommand>
    {
        public AdcionarMarcaCommandValidator()
        {
            RuleFor(x => x.Nome)
        .NotEmpty().WithMessage("O nome da marca é obrigatório")
        .Length(2, 90).WithMessage("O nome da marca deve ter entre 2 e 90 caracteres");
        }
    }
}
