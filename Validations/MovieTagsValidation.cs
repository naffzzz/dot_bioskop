using System;
using FluentValidation;
using dot_bioskop.Models;

namespace dot_bioskop.Validations
{
    public class MovieTagsValidation: AbstractValidator<movie_tags>
    {
        public MovieTagsValidation()
        {
            RuleFor(x => x.movie_id).NotEmpty().WithMessage("Movietidak boleh kosong");
            RuleFor(x => x.tag_id).NotEmpty().WithMessage("Tag tidak boleh kosong");
        }
    }
}
