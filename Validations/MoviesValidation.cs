using System;
using FluentValidation;
using dot_bioskop.Models;

namespace dot_bioskop.Validations
{
    public class MoviesValidation: AbstractValidator<movies>
    {
        public MoviesValidation()
        {
            RuleFor(x => x.title).NotEmpty().WithMessage("Judul tidak boleh kosong");
            RuleFor(x => x.overview).NotEmpty().WithMessage("Sinopsis tidak boleh kosong");
            RuleFor(x => x.poster).NotEmpty().WithMessage("Poster tidak boleh kosong");
            RuleFor(x => x.play_until).NotEmpty().WithMessage("Waktu berhenti tidak boleh kosong");
        }
    }
}
