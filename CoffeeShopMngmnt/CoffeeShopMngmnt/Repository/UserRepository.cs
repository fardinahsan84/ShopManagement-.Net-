using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoffeeShopMngmnt.Model;
using CoffeeShopMngmnt.Interface;

namespace CoffeeShopMngmnt.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public IEnumerable<User> GetHighestPaidEmployees()
        {
            throw new NotImplementedException();
        }
    }
}