using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategi adını boş geçemezsiniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Kategi açıklamasını boş geçemezsiniz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Kategi adı en fazla 50 karakter olmalıdır");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Kategi adı en az 2 karakter olmalıdır");
        }
    }
}
