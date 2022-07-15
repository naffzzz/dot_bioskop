using System;
using FluentValidation;
using dot_bioskop.Models;

namespace dot_bioskop.Validations
{
    public class LoginsValidation: AbstractValidator<logins>
    {
        public LoginsValidation()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage("Email tidak boleh kosong");
            RuleFor(x => x.password).NotEmpty().WithMessage("Password tidak boleh kosong");
        }
    }
}
