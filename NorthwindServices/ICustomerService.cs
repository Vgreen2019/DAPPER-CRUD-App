using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.NorthwindServices
{
    public interface ICustomerService
    {
        CustomersViewModel GettingCustomers();
        //CustomersViewModel GetCustomer(string firstName);
    }
}
