using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoffeeShopMngmnt.Model;
using CoffeeShopMngmnt.Interface;

namespace CoffeeShopMngmnt.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {

        public IEnumerable<Item> GetHighest()
        {
            throw new NotImplementedException();
        }
    }
}