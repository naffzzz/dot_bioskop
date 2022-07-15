using System;
using FluentValidation;
using dot_bioskop.Models;

namespace dot_bioskop.Validations
{
    public class StudiosValidation: AbstractValidator<studios>
    {
        public StudiosValidation()
        {
            RuleFor(x => x.studio_number).NotEmpty().WithMessage("Nomor studio tidak boleh kosong");
            RuleFor(x => x.seat_capacity).NotEmpty().WithMessage("Kapasitas tempat duduk tidak boleh kosong");
        }
    }
}
