using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.NorthwindServices
{
    public interface IProductService
    {
       ProductsViewModel GettingProducts();
        AProductViewModel GetProductInfo(int id);
        ProductsViewModel AddNewProduct(AddProductViewModel model);
        ProductsViewModel RemoveProduct(int id);
        ProductsViewModel EditProduct(AProductViewModel model);


    }
}
