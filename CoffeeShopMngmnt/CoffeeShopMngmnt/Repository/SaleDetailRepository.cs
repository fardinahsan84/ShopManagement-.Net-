using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoffeeShopMngmnt.Model;
using CoffeeShopMngmnt.Interface;

namespace CoffeeShopMngmnt.Repository
{
    public class SaleDetailRepository : Repository<Sale_Detail>, ISaleDetailsRepo
    {

        public IEnumerable<Sale_Detail> GetHighestPaids()
        {
            throw new NotImplementedException();
        }
    }
}