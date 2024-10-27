using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail boş geçilemez");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi alanı boş geçilemez");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez");


            RuleFor(x => x.Name).MinimumLength(5).WithMessage("İsim alanına en az 5 karakter giriniz")
                .MaximumLength(50).WithMessage("İsim alanına en fazla 50 karakter giriniz");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama alanına maksimum 500 karakter girebilirsiniz.");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");
                
        }
    }
}
