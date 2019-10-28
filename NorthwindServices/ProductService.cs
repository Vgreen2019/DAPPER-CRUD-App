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
            dalModel.QuantityPerUnit = model.QuantityPerUnit;     //MIGHT NEED TO ADD PRODUCT ID

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

        //public ProductsViewModel RemoveProduct(int id)
        //{
        //    var dalProduct = _productStore.DeleteProduct(id);

        //    var product = new AProductViewModel();
        //    product.ID = dalProduct.ProductID;
        //    product.Name = dalProduct.ProductName;
        //    product.SupplierID = dalProduct.SupplierID;
        //    product.CategoryID = dalProduct.CategoryID;
        //    product.QuantityPerUnit = dalProduct.QuantityPerUnit;
        //    product.UnitPrice = dalProduct.UnitPrice;
        //    product.UnitsInStock = dalProduct.UnitsInStock;
        //    product.UnitsOnOrder = dalProduct.UnitsOnOrder;

        //    var dalProducts = _productStore.SelectAllProducts();
        //    var products = new List<Product>();


        //    if (products.Contains(product))
        //    {
        //        products.Remove(product);
        //    }


        //    //foreach (var dalProduct in dalProducts)
        //    //{
        //    //    var product = new Product();
        //    //    product.Name = dalProduct.ProductName;
        //    //    product.ID = dalProduct.ProductID;      //MIGHT NEED TO REMOVE PRODUCT ID
        //    //    product.SupplierID = dalProduct.SupplierID;
        //    //    product.CategoryID = dalProduct.CategoryID;
        //    //    product.QuantityPerUnit = dalProduct.QuantityPerUnit;
        //    //    product.UnitPrice = dalProduct.UnitPrice;
        //    //    product.UnitsInStock = dalProduct.UnitsInStock;
        //    //    product.UnitsOnOrder = dalProduct.UnitsOnOrder;

        //    //    products.Remove(product);
        //    //}


        //    var productModel = new ProductsViewModel();
        //    productModel.Products = products;

        //    return productModel;


        //}

        public ProductsViewModel RemoveProduct(AProductViewModel model)
        {
            var dalModel = new ProductDALModel();

            model.ID = dalModel.ProductID;
            model.Name = dalModel.ProductName;
            model.SupplierID = dalModel.SupplierID;
            model.CategoryID = dalModel.CategoryID;
            model.QuantityPerUnit = dalModel.QuantityPerUnit;
            model.UnitPrice = dalModel.UnitPrice;
            model.UnitsInStock = dalModel.UnitsInStock;
            model.UnitsOnOrder = dalModel.UnitsOnOrder;

            _productStore.DeleteProduct(dalModel);

            var dalProducts = _productStore.SelectAllProducts();
            var products = new List<Product>();

            foreach (var dalProduct in dalProducts)
            {
                var product = new Product();
                product.Name = dalProduct.ProductName;
                product.ID = dalProduct.ProductID;      //MIGHT NEED TO REMOVE PRODUCT ID
                product.SupplierID = dalProduct.SupplierID;
                product.CategoryID = dalProduct.CategoryID;
                product.QuantityPerUnit = dalProduct.QuantityPerUnit;
                product.UnitPrice = dalProduct.UnitPrice;
                product.UnitsInStock = dalProduct.UnitsInStock;
                product.UnitsOnOrder = dalProduct.UnitsOnOrder;

                products.Remove(product);
            }

            var productModel = new ProductsViewModel();
            productModel.Products = products;

            return productModel;


        }

        public ProductsViewModel EditProductName(AProductViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
