using DapperDemo.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.DAL
{
    public interface IProductStore
    {
        IEnumerable<ProductDALModel> SelectAllProducts();
        ProductDALModel SelectAProduct(int id);
        bool InsertNewProduct(ProductDALModel dalModel);
        bool DeleteProduct(int id);
        bool UpdateProduct(ProductDALModel dalModel);
        IEnumerable<ProductDALModel> SearchAProduct(string search);


    }
}
