using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDemo.DAL;
using DapperDemo.Models;

namespace DapperDemo.NorthwindServices
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerStore _customerStore;

        public CustomerService(ICustomerStore customerStore)
        {
            _customerStore = customerStore;
        }

        //public CustomersViewModel GetCustomer(string firstName)
        //{
        //    var dalCustomer = _customerStore.SelectACustomer(firstName);

        //    var customerInfo = new CustomersViewModel();

        //    foreach (var dalCusto in dalCustomer)
        //    {
        //        var customer = new Customer();
        //        customer.Id = dalCusto.CustomerID;
        //        customer.CompanyName = dalCusto.CompanyName;
        //        customer.ContactName = dalCusto.ContactName;
        //        customer.Address = dalCusto.Address;
        //        customer.City = dalCusto.City;
        //        customer.Region = dalCusto.Region;
        //        customer.PostalCode = dalCusto.PostalCode;
        //        customer.Country = dalCusto.Country;
        //        customer.Phone = dalCusto.Phone;

        //        customerInfo.Add(customer);

        //    }
        //    var customerViewModel = new CustomersViewModel();
        //    customerViewModel.Customers = customerInfo;

        //    return customerViewModel;
        //}

        public CustomersViewModel GettingCustomers()
        {
            var dalCustomers = _customerStore.SelectAllCustomers();

            var customers = new List<Customer>();

            foreach (var dalCustomer in dalCustomers)
            {
                var customer = new Customer();
                customer.Id = dalCustomer.CustomerID;
                customer.CompanyName = dalCustomer.CompanyName;
                customer.Address = dalCustomer.Address;
                customer.City = dalCustomer.City;
                customer.Region = dalCustomer.Region;
                customer.PostalCode = dalCustomer.PostalCode;
                customer.Country = dalCustomer.Country;
                customer.Phone = dalCustomer.Phone;

                customers.Add(customer);

            }

            var customerViewModel = new CustomersViewModel();
            customerViewModel.Customers = customers;

            return customerViewModel;

        }
             
    }
}
