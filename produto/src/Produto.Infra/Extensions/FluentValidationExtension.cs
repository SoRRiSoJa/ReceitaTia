using FluentValidation.Results;
using Produto.Application.DTOs;

namespace Produtos.Infra.Extensions
{
    public static class FluentValidationExtension
    {
        public static List<MessageResult> GetErrors(this ValidationResult result)
        {
            return result.Errors?.Select(error => new MessageResult(error.PropertyName, error.ErrorMessage)).ToList();
        }
    }
}
