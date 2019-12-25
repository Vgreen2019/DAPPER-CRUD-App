using Dapper;
using DapperDemo.DAL.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

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

            using (var connection = new SqlConnection(_config.ConnectionString2))    //using statement to manage memory. This will always implement an IDisposable, which closes the connection
            {
                var results = connection.Query<ProductDALModel>(sql) ?? new List<ProductDALModel>();
                //not adding or removing from the list, this is why we use the type of IEnumerable called List
                return results;

            }
        }

        public ProductDALModel SelectAProduct(int id)
        {
            var sql = @"SELECT * FROM Products WHERE ProductID = @ProductID";       

            using (var connection = new SqlConnection(_config.ConnectionString2))    
            {
                var results = connection.QueryFirstOrDefault<ProductDALModel>(sql, new { ProductID = id });
                return results;

            }
        }

        public bool InsertNewProduct(ProductDALModel dalModel) 
        {
            var sql = $@"INSERT INTO Products (ProductName, QuantityPerUnit) 
                            VALUES (@{nameof(dalModel.ProductName)}, @{nameof(dalModel.QuantityPerUnit)})";

            using (var connection = new SqlConnection(_config.ConnectionString2))
            {
                var results = connection.Execute(sql, dalModel);
                
                return true;
            }


        }

        public bool DeleteProduct(int id)     
        {
            var sql = $@"DELETE FROM Products WHERE ProductID = @ProductID";

            using (var connection = new SqlConnection(_config.ConnectionString2))
            {
                var results = connection.Execute(sql, new { ProductID = id });     

                return true;
            }
        }

         

        public bool UpdateProduct(ProductDALModel dalModel)
        {                                                       
            var sql = $@"UPDATE Products 
                         SET ProductName = @{nameof(dalModel.ProductName)}, CategoryID = @{nameof(dalModel.CategoryID)}, QuantityPerUnit = @{nameof(dalModel.QuantityPerUnit)}, SupplierID = @{nameof(dalModel.SupplierID)},
                         UnitPrice = @{nameof(dalModel.UnitPrice)}, UnitsInStock = @{nameof(dalModel.UnitsInStock)}, UnitsOnOrder = @{nameof(dalModel.UnitsOnOrder)}
                         WHERE ProductID = @{nameof(dalModel.ProductID)}"; 

            using (var connection = new SqlConnection(_config.ConnectionString2))
            {
                var results = connection.Execute(sql, dalModel);      

                return true;
            }
        }
    }
}
