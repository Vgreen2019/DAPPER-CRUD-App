using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperDemo.DAL.Model;

namespace DapperDemo.DAL
{
    public class ProductStore : IProductStore
    {
        private readonly Database _config;

        public ProductStore(DapperDemoConfiguration config)
        {
            _config = config.Database;
        }

        public IEnumerable<ProductDALModel> SelectAllProducts()
        {
            var sql = @"SELECT * FROM Products ORDER BY ProductName ASC";

            using (var connection = new SqlConnection(_config.ConnectionString))    //using statement to manage memory. This will always implement an IDisposable, which closes the connection
            {
                var results = connection.Query<ProductDALModel>(sql) ?? new List<ProductDALModel>();
                //not adding or removing from the list, this is why we use the type of IEnumerable called List
                return results;

            }
        }

        public ProductDALModel SelectAProduct(int id)
        {
            var sql = @"SELECT * FROM Products WHERE ProductID = @ProductID";       

            using (var connection = new SqlConnection(_config.ConnectionString))    
            {
                var results = connection.QueryFirstOrDefault<ProductDALModel>(sql, new { ProductID = id});
                return results;

            }
        }

        public bool InsertNewProduct(ProductDALModel dalModel)  //MIGHT HAVE TROUBLE WITH DATA TYPES, ESP DISCONTINUED
        {
            var sql = $@"INSERT INTO Products (ProductName, QuantityPerUnit) 
                            VALUES (@{nameof(dalModel.ProductName)}, @{nameof(dalModel.QuantityPerUnit)})";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var results = connection.Execute(sql, dalModel);
                
                return true;
            }


        }

        public bool DeleteProduct(ProductDALModel dalModel)     //MIGHT NEED TO ALTER THE INPUT by adding productDALModel
        {
            var sql = $@"DELETE FROM Products WHERE ProductID = @{nameof(dalModel.ProductID)}";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var results = connection.Execute(sql, dalModel);      //MIGHT NEED A DIFFERENT EXECUTE METHOD

                return true;
            }
        }


        //public bool DeleteProduct(int id)     //MIGHT NEED TO ALTER THE INPUT by adding productDALModel
        //{
        //    var sql = @"DELETE FROM Products WHERE ProductID = @ProductID";

        //    using (var connection = new SqlConnection(_config.ConnectionString))
        //    {
        //        var results = connection.Execute(sql, new { ProductID = id });      //MIGHT NEED A DIFFERENT EXECUTE METHOD

        //        return true;
        //    }
        //}

        public bool UpdateProduct(ProductDALModel dalModel)
        {
            var sql = $@"UPDATE Products SET ProductName = 'THE NEW NEW' WHERE ProductID = @{nameof(dalModel.ProductID)}";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var results = connection.Execute(sql, dalModel);      //MIGHT NEED A DIFFERENT EXECUTE METHOD

                return true;
            }
        }
    }
}
