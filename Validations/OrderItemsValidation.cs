using System;
using FluentValidation;
using dot_bioskop.Models;

namespace dot_bioskop.Validations
{
    public class OrderItemsValidation: AbstractValidator<order_items>
    {
        public OrderItemsValidation()
        {
            RuleFor(x => x.order_id).NotEmpty().WithMessage("Order tidak boleh kosong");
            RuleFor(x => x.movie_schedule_id).NotEmpty().WithMessage("Jadwal movie tidak boleh kosong");
            RuleFor(x => x.qty).NotEmpty().WithMessage("Kuantitas tidak boleh kosong");
            RuleFor(x => x.price).NotEmpty().WithMessage("Harga tidak boleh kosong");
            RuleFor(x => x.sub_total_price).NotEmpty().WithMessage("Sub total harga tidak boleh kosong"); 
        }
    }
}
