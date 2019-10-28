using DapperDemo.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.DAL
{
    public interface ICustomerStore
    {
        IEnumerable<CustomerDALModel> SelectAllCustomers();
        //IEnumerable<CustomerDALModel> SelectACustomer(string firstname);


    }
}

