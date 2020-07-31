using LayeredArchitecture.Dal.Abstract;
using LayeredArchitecture.Entities.Models;
using LayeredArchitecture.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LayeredArchitecture.Bll
{
    public class CustomerManager:GenericManager<Customers>,ICustomerService
    {
        ICustomerRepository customerRepository;

        public CustomerManager(ICustomerRepository customerRepository):base(customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public List<Customers> CustomerListByCity(string city)
        {
            return customerRepository.CustomersList(city);
        }
    }
}
