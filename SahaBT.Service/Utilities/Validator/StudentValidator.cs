using FluentValidation;
using SahaBT.Shared.Model.ViewModel;

namespace SahaBT.Shared.Validator
{
    public class StudentValidator : AbstractValidator<StudentLessonAddModel>
    {
        public StudentValidator()
        {
            RuleFor(c => c.StudentName).NotEmpty().WithMessage("Lütfen adınızı boş geçmeyiniz.");
            RuleFor(c => c.StudentAge).NotEmpty().WithMessage("Lütfen yaşınızı boş geçmeyiniz.");
            RuleFor(c => c.LessonCode).NotEmpty().WithMessage("Lütfen ders kodu seçiniz.").MaximumLength(6);
        }
    }
}
