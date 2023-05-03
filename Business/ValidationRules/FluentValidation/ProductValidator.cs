using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {

            RuleFor(p=>p.ProductName).NotEmpty();//boş olamaz
            RuleFor(p=>p.ProductName).MinimumLength(2);
            RuleFor(p=>p.UnitPrice).NotEmpty();
            RuleFor(p=>p.UnitPrice).GreaterThan(0);//0 dan buyük olsun
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);//.WithMessage("") hata mesajını yazdırabılırız. 
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");//Must : uymalı

        }

        private bool StartWithA(string productName)
        {
            return productName.StartsWith("A");//A ile başlıyorsa True değilse False döner
        }
    }
}
