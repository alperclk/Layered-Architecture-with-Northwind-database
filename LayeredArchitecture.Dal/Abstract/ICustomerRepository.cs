using LayeredArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Dal.Abstract
{
    public interface ICustomerRepository:IGenericRepository<Customers>
    {
        List<Customers> CustomersList(string city);
    }
}
