using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
            new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitPrice=15, UnitsInStock=15},
            new Product{CategoryId=2,ProductId=1,ProductName="Bardak",UnitPrice=15, UnitsInStock=15},
            new Product{CategoryId=3,ProductId=2,ProductName="Kamera",UnitPrice=115, UnitsInStock=11},
            new Product{CategoryId=4,ProductId=2,ProductName="Kamera",UnitPrice=151, UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete =  _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //foreach (var p in _products)
            //{
            //    if(p.ProductId==product.ProductId)
            //    {
            //        productToDelete = p;
            //    }

            //}
           
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün id sine sahip olan ürün ıd sini bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId=product.CategoryId;
        }

       public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        List<Product> IEntityRepository<Product>.GetAll(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        Product IEntityRepository<Product>.Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
