using CoffeeShopMngmnt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopMngmnt.Interface
{
    public interface ISaleDetailsRepo : IRepository<Sale_Detail>
    {
        IEnumerable<Sale_Detail> GetHighestPaids();
    }
}
