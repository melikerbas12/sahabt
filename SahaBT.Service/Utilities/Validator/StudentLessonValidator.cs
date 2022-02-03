using FluentValidation;
using SahaBT.Shared.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahaBT.Service.Utilities.Validator
{
    public class StudentLessonValidator : AbstractValidator<StudentLessonUpdateModel>
    {
        public StudentLessonValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Lütfen id alanını geçmeyiniz.");
        }
    }
}
