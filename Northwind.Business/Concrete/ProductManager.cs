using FluentValidation;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.Concrete.Utilities;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        //EfProductDal _productDal = new EfProductDal(); //dependency 
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {//ctor : ProductManager newlendiğinde bana IPRoductDal türünde nesne verilsin ; Nh ya da Ef
            _productDal = productDal;
        }
        //Dependency Injection için constructor ile dataacceslayerdaki hangi concrete sınıf ile çalışacağımızı
        //manager da soyut olarak verdik ve formda kullanıcıdan onun somutunu istedik

        public List<Product> GetAll()
        {//business code  
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);

            }
            catch
            {
                //hatayı ara yüze bu şekilde yansıttık
                throw new Exception();
            }
        }
    }
}


//projenin farklı bir veritabanını desteklemesini istersem?

// SOLID : O — Open-closed principle : Bir sınıf ya da fonksiyon halihazırda var olan özellikleri korumalı
// ve değişikliğe izin vermemelidir. Yani davranışını değiştirmiyor olmalı ve yeni özellikler kazanabiliyor olmalıdır.
// Yazılım varlıkları (sınıflar, modüller, işlevler vb.) genişletmeye açık, ancak değişiklik için kapalı olmalıdır

//SOLID : D — Dependency Inversion Principle
//ÖZET: Sınıflar arası bağımlılıklar olabildiğince az olmalıdır özellikle üst seviye sınıflar alt seviye sınıflara bağımlı olmamalıdır.
// (bir katman başka bir katmanı newlememeli)


