using LayeredArchitecture.Dal.Abstract;
using LayeredArchitecture.Dal.Concrete.EntityFramework.Context;
using LayeredArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Dal.Concrete.EntityFramework.Repository
{
    public class EfCustomerRepository : EfGenericRepository<Customers>, ICustomerRepository
    {
        public EfCustomerRepository()
        {
            northwindContext = new NorthwindContext();
        }

        public List<Customers> CustomersList(string city)
        {
            return northwindContext.Customers.Where(x => x.City.Equals(city)).ToList();
        }
    }
}
