using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperDemo.DAL.Model;

namespace DapperDemo.DAL
{
    public class CustomerStore: ICustomerStore
    {
        private readonly Database _config;

        public CustomerStore(DapperDemoConfiguration config)
        {
            _config = config.Database;
        }

        public IEnumerable<CustomerDALModel> SelectACustomer(string firstName)
        {
            var sql = @"SELECT * FROM Customers WHERE ContactName LIKE '(@ContactName)%'";

            using (var connection = new SqlConnection(_config.ConnectionString))   
            {
                var results = connection.Query<CustomerDALModel>(sql) ?? new List<CustomerDALModel>();
                return results;

            }
        }

        public IEnumerable<CustomerDALModel> SelectAllCustomers()
        {
            var sql = @"SELECT * FROM Customers";

            using (var connection = new SqlConnection(_config.ConnectionString))    //using statement to manage memory. This will always implement an IDisposable, which closes the connection
            {
                var results = connection.Query<CustomerDALModel>(sql) ?? new List<CustomerDALModel>();
                //not adding or removing from the list, this is why we use the type of IEnumerable called List
                return results;

            }
        }

    }
}

