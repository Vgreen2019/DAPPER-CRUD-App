﻿using System;
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

        public IActionResult GetAllProducts() 
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
            return View("GetAllProducts", productsViewModel);
        }

        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.GetProductInfo(id );

            return View(result);
        }

        public IActionResult RemoveProductResults(int id)
        {
            var productsViewModel = _productService.RemoveProduct(id); 
            return View("GetAllProducts", productsViewModel);
        }

        public IActionResult EditProduct(AProductViewModel model)     
        {
            var getProduct = _productService.GetProductInfo(model.ID);

            return View(getProduct);   
        }

        public IActionResult EditProductResults(AProductViewModel model)
        {
            var editedProduct = _productService.EditProduct(model);  
            return View("GetAllProducts", editedProduct);
        }

        public IActionResult SearchProduct()
        {
            return View();
        }

        public IActionResult SearchProductResults(SearchProductViewModel model)
        {
            var results = _productService.SearchProduct(model.SearchTerm);
            return (results.Products.Count() == 0) ? View("ProductDoesntExist") : View(results);
        }

    }
}
