using Northwind.Entities.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //filtre; ben sana T vereceğim, dönüş türü bool olacak
        //kullanıcı filtre verirse onları getir, vermezse hepsini getir 
        T Get(Expression<Func<T, bool>> filter);
        //mutlaka filtre verilsin
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

//ne tür gönderirsem göndereyim(Product,Customer,...) hepsinde kullanılsın
//Genericler ile sıklıkla yaptığımız işlemleri nesne bazlı değiştirebiliriz 
//  void Update(Product product); YERİNE void Update(T entity);
// entity genel bir isim vermek için


