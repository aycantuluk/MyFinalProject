using Business.Abstract;
using Entities.Concreate;
using DataAccess.Concreate.InMemory;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concreate
{
    
    public class ProductManager : IProductServices
    {

        IProductDal _productDal;
      
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
    
        public IResult All(Product product)
        {
            if(product.ProductName.Length<2)
            {
                return new ErorResult(Mesagess.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Mesagess.ProductAdded);
        }

        public IDataResult <List<Product>> GetAll()
        {
            if(DateTime.Now.Hour==22)
            {
                return new ErorDataResults<List<Product>>(Mesagess.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Mesagess.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return  new SuccessDataResults<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

  

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResults<List<Product>>( _productDal.GetAll(p => p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new  SuccessDataResults<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


        public IDataResult<List<Product>> GetById(int Id)
        {
            return new SuccessDataResults<List<Product>>(_productDal.GetAll(p => p.CategoryId == Id)); 
        }
    }
}
