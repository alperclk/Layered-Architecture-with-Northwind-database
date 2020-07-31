using LayeredArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Interfaces
{
    public interface ICustomerService:IGenericService<Customers>
    {
        List<Customers> CustomerListByCity(string city);
    }
}
