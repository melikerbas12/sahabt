using FluentValidation;
using SahaBT.Shared.Pagination;

namespace SahaBT.Service.Utilities.Validator
{
    public class PagingValidator : AbstractValidator<PagingParameters>
    {
        public PagingValidator()
        {
            RuleFor(c => c.PageNumber).NotEmpty().WithMessage("Sayfa sayısı boş geçilemez.");
            RuleFor(c => c.PageSize).NotEmpty().WithMessage("Data sayısı boş geçilemez.");
        }
    }
}
