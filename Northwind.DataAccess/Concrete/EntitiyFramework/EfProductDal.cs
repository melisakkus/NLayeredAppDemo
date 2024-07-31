using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntitiyFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{//veri tabanı işlemleri yapıyoruz
    public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    // ProductDal - EfProductDal olarak isimlendirdik : EntityFrameworkProductDal
    {

    }
}


//SingleOrDefault yöntemi, LINQ (Language Integrated Query) kullanarak bir koleksiyondan belirli bir koşulu karşılayan
//tek bir öğeyi seçmek için kullanılır. Eğer bu koşulu karşılayan yalnızca bir öğe varsa, bu öğeyi döndürür; koşulu karşılayan
//öğe yoksa null döner. Koşulu karşılayan birden fazla öğe varsa, bir InvalidOperationException hatası fırlatır.