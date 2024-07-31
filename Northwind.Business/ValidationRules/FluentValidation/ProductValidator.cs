using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product> //Product için kurallar yazıyoruz
    {
        public ProductValidator()
        {
            RuleFor(p=>p.ProductName).NotEmpty().WithMessage("Product Name can not be empty!");
            RuleFor(p=>p.CategoryId).NotEmpty();
            RuleFor(p=>p.UnitPrice).NotEmpty();
            RuleFor(p=>p.QuantityPerUnit).NotEmpty();
            RuleFor(p=>p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2).WithMessage("Unit Price should be greater than 10");

            //kendi kuralımızı oluşturabiliriz
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Product name should start with 'A' .");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}


// kullanıcının girdiği nesnenin bizim kurallarımıza uygun olması : validasyon (doğrulama)
// fiyatın 0'dan büyük olması, ürün adının mutlaka girilmiş olması gibi
// bu kuralları iş katmanında gireriz : fluent validation aracını kullanalım
//snippet : constructor için ctor olması