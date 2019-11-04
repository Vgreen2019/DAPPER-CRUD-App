using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDemo.DAL;
using DapperDemo.DAL.Model;
using DapperDemo.Models;

namespace DapperDemo.NorthwindServices
{
    public class ProductService : IProductService
    {
        private readonly IProductStore _productStore;

        public ProductService(IProductStore productStore)
        {
            _productStore = productStore;
        }
               
       
        public ProductsViewModel GettingProducts()
        {
            var dalProducts = _productStore.SelectAllProducts();
            var products = new List<Product>();

            foreach (var dalProduct in dalProducts)
            {
                var product = new Product();
                product.Name = dalProduct.ProductName;
                product.ID = dalProduct.ProductID;
               
                products.Add(product);
            }

            var productModel = new ProductsViewModel();
            productModel.Products = products;

            return productModel;
        }

        public AProductViewModel GetProductInfo(int id)
        {
            var dalProduct = _productStore.SelectAProduct(id);

            var product = new AProductViewModel();
            product.ID = dalProduct.ProductID;
            product.Name = dalProduct.ProductName;
            product.SupplierID = dalProduct.SupplierID;
            product.CategoryID = dalProduct.CategoryID;
            product.QuantityPerUnit = dalProduct.QuantityPerUnit;
            product.UnitPrice = dalProduct.UnitPrice;
            product.UnitsInStock = dalProduct.UnitsInStock;
            product.UnitsOnOrder = dalProduct.UnitsOnOrder;

            return product;
        }

        public ProductsViewModel AddNewProduct(AddProductViewModel model)
        {

            var dalModel = new ProductDALModel();
            dalModel.ProductName = model.Name;
            dalModel.QuantityPerUnit = model.QuantityPerUnit;     

            _productStore.InsertNewProduct(dalModel);

            var dalProducts = _productStore.SelectAllProducts();
            var products = new List<Product>();

            foreach (var dalProduct in dalProducts)
            {
                var product = new Product();
                product.Name = dalProduct.ProductName;
                product.ID = dalProduct.ProductID;      //MIGHT NEED TO REMOVE PRODUCT ID
                product.QuantityPerUnit = dalProduct.QuantityPerUnit;

                products.Add(product);
            }

            var productModel = new ProductsViewModel();
            productModel.Products = products;

            return productModel;
        }

        public ProductsViewModel RemoveProduct(int id)
        {
            var dalModel = new ProductDALModel();
            _productStore.DeleteProduct(id);

            var dalProducts = _productStore.SelectAllProducts();
            var products = new List<Product>();

            foreach (var dalProduct in dalProducts)
            {
                var product = new Product();
                product.Name = dalProduct.ProductName;
                product.ID = dalProduct.ProductID;

                products.Add(product);
            }

                                
            var productModel = new ProductsViewModel();
            productModel.Products = products;

            return productModel;


        }

       
        public ProductsViewModel EditProduct(AProductViewModel model)
        {
            var dalModel = new ProductDALModel();
            dalModel.ProductID = model.ID;
            dalModel.ProductName = model.Name;
            dalModel.QuantityPerUnit = model.QuantityPerUnit;

            _productStore.UpdateProduct(dalModel);

            var dalProducts = _productStore.SelectAllProducts();
            var products = new List<Product>();

            foreach (var dalProduct in dalProducts)
            {
                var product = new Product();
                product.Name = dalProduct.ProductName;
                product.ID = dalProduct.ProductID;

                products.Add(product);
            }


            var productModel = new ProductsViewModel();
            productModel.Products = products;

            return productModel;
        }
    }
}
