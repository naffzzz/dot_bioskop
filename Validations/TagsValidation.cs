using System;
using FluentValidation;
using dot_bioskop.Models;

namespace dot_bioskop.Validations
{
    public class TagsValidation: AbstractValidator<tags>
    {
        public TagsValidation()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Nama tag tidak boleh kosong");
        }
    }
}
