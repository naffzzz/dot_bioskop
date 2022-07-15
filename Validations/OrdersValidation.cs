using System;
using FluentValidation;
using dot_bioskop.Models;

namespace dot_bioskop.Validations
{
    public class OrdersValidation: AbstractValidator<orders>
    {
        public OrdersValidation()
        {
            RuleFor(x => x.user_id).NotEmpty().WithMessage("User id tidak boleh kosong");
            RuleFor(x => x.payment_method).NotEmpty().WithMessage("Metode pembayaran tidak boleh kosong");
            RuleFor(x => x.total_item_price).NotEmpty().WithMessage("harga total item tidak boleh kosong");
        }
    }
}
