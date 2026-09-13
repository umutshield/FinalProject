using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        //kurallar constructor'ın içine yazılır.
        //bu kuralları ayrıca kendin araştır
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();         //ürünün ismi boş olmamalı
            RuleFor(p => p.ProductName).MinimumLength(2);     //ürünün ismi min 2 karakter olsun kuralını yazdık
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);         //ürünün fiyatı 0 dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);  //ürünün fiyatı 10 dan büyük olsun ama 1 nolu kategori id'ye sahip ürünler için
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");    //ürünlerim A ile başlamalı. (must uymalı demek)

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");      //arg senin gönderdiğin parametredir yani ProductName'dir.
        }
    }
}
