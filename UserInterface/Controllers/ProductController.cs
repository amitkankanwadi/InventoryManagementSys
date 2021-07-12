using System.Collections.Generic;
using Business.Product.Entities;
using Business.Product.Implementation;
using Core.Common;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    [Route("api/[controller]")]
    public class ProductController
    {
        private ProductManagement productClass = new ProductManagement("", "", 0);
        public void ProductManagement(string name, string desc, float rate)
        {
            productClass = new ProductManagement(name, desc, rate);
        }

        [HttpPost]
        [Route("Add")]
        public BaseReturn<EProduct> AddProduct([FromBody] EProduct product)
        {
            return productClass.AddProduct(product);
        }

        [HttpPost]
        [Route("Delete")]
        public BaseReturn<EProduct> RemoveProduct([FromBody] EProduct product)
        {
            return productClass.RemoveProduct(product);
        }

        [HttpPost]
        [Route("GetAll")]
        public BaseReturn<List<EProduct>> GetAllProducts()
        {
            return productClass.GetAllProducts();
        }

        [HttpPost]
        [Route("Update")]
        public BaseReturn<EProduct> UpdateProduct([FromBody] EProduct product)
        {
            return productClass.UpdateProduct(product);
        }

        [HttpPost]
        [Route("AddStock")]
        public BaseReturn<EStocks> AddStock([FromBody] EStocks product)
        {
            return productClass.AddStock(product);
        }

        [HttpPost]
        [Route("DeleteStock")]
        public BaseReturn<EStocks> RemoveStock([FromBody] EStocks product)
        {
            return productClass.RemoveStock(product);
        }

        [HttpPost]
        [Route("GetProductStock")]
        public BaseReturn<EStocks> GetProductStock([FromBody] EStocks product)
        {
            return productClass.GetProductStock(product);
        }

        [HttpPost]
        [Route("UpdateStock")]
        public BaseReturn<EStocks> UpdateStock([FromBody] EStocks product)
        {
            return productClass.UpdateStock(product);
        }

        [HttpPost]
        [Route("GetReport")]
        public BaseReturn<List<EStocks>> GetReport([FromBody] EStocks product)
        {
            return productClass.GetReport(product);
        }
    }
}