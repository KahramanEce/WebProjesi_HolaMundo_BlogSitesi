using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        //Fluent Validation(kontrol saglama) kullandik.
        public UserValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Yazar Adı Soyadı kısmı boş geçilemez");     //NotEmpty()=Bos gecilemez.
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.Email).Matches(@"[@,.]+").WithMessage("Mail adresi '@'ve '.' içermelidir");
            //RuleFor(x => x.PasswordHash).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("Lütfen en az iki karakter girişi yapın");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Lütfen en fazla elli karakterlik veri girişi yapın");
            //RuleFor(x => x.PasswordHash).Matches(@"[A-Z]+").WithMessage("Şifre en az bir büyük harf içermelidir");


        }
    }
}
