using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoffeeShopMngmnt.Model;
using CoffeeShopMngmnt.Interface;

namespace CoffeeShopMngmnt.Repository
{
    public class SaleRepository: Repository<Sale>, ISaleRepository
    {

        public IEnumerable<Sale> GetHighestPaid()
        {
            throw new NotImplementedException();
        }
    }
}