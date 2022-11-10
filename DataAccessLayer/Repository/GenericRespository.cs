using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRespository<T> : IGenericDal<T> where T : class,new()
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public List<T> GetbyFilter(Expression<Func<T, bool>> filter)//Şartlı listeleme için
        {
            using var c = new Context();
            return c.Set<T>().Where(filter).ToList();
        }

        public T GetByID(int id)
        {
            using (var c = new Context())
            {
                return c.Set<T>().Find(id); //id geleni bul ;
            } 
        }
        public List<T> GetList()
        {
            using var c = new Context();

            var result = c.Set<T>();
            return result.ToList();
        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
