using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator()
        {
            RuleFor(x => x.NotificationType).NotEmpty().WithMessage("Bildirim başlığını boş geçemezsiniz!");
            RuleFor(x => x.NotificationDetails).NotEmpty().WithMessage("Bildirim içeriğini boş geçemezsiniz!");
        }
    }
}
