﻿using CoffeeShopMngmnt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopMngmnt.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetHighestPaidEmployees();
    }
}
