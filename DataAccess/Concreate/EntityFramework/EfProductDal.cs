using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //ıdisposible pattern implamentation of c#
            using (NortwindContext nortwindContext=new NortwindContext())
            {
                var addedEntity = nortwindContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                nortwindContext.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NortwindContext nortwindContext = new NortwindContext())
            {
                var deletedEntity = nortwindContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                nortwindContext.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NortwindContext nortwindContext = new NortwindContext())
            {
                return nortwindContext.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NortwindContext nortwindContext = new NortwindContext())
            {
                return filter == null ? nortwindContext.Set<Product>().ToList(): nortwindContext.Set<Product>().Where(filter).ToList();
            }

        }
        public void Update(Product entity)
        {
            using (NortwindContext nortwindContext = new NortwindContext())
            {
                var updatedEntity = nortwindContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                nortwindContext.SaveChanges();
            }
        }
    }
}
