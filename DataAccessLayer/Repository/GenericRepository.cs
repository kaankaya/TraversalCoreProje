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
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            using var c = new Context();
            if (filter == null)
            {
                return c.Set<T>().ToList();
            }
            else
            {
                return c.Set<T>().Where(filter).ToList();
            }
        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
        }
    }
}
