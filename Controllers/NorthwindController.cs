using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDemo.DAL;
using DapperDemo.Models;
using DapperDemo.NorthwindServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperDemo.Controllers
{
    public class NorthwindController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public NorthwindController(ICustomerService customerService, IProductService productService)
        {
            _customerService = customerService;
            _productService = productService;
        }
        
        public IActionResult Customer()
        {
            var result = _customerService.GettingCustomers();
            return View(result);
        }

        //public IActionResult ACustomer()
        //{
        //    var result = _customerService.GetCustomer(string firstName);
        //    return View(result);
        //}

        public IActionResult Product() 
        {
            var result = _productService.GettingProducts();
            return View(result);
        }

        public IActionResult ProductInfo(int id)
        {
            var result = _productService.GetProductInfo(id);
            return View(result);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult AddProductResults(AddProductViewModel model)
        {
            var productsViewModel = _productService.AddNewProduct(model);  
            return View("Product", productsViewModel);
        }

        public IActionResult DeleteProduct()
        {
            return View();
        }

        public IActionResult RemoveProductResults(AProductViewModel model)
        {
            var productsViewModel = _productService.RemoveProduct(model);  //need to be fixed
            return View("Product", productsViewModel);
        }

        public IActionResult EditProduct(AProductViewModel model)
        {
            var productsViewModel = _productService.EditProductName(model);  //need to be fixed
            return View("Product", productsViewModel);
        }

    }
}
