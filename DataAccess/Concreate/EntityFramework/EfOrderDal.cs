using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concreate.EntityFramework;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concreate
{
   public class EfOrderDal: EfEntityRepositoryBase<Order, NortwindContext>, IOrderDal
    {
    }
}
