using Business.Account.Entities;
using System;
using System.Collections.Generic;
using Core.Common;
using Business.Product.Entities;
using System.Linq;

namespace Business.Product.Implementation
{
    public class ProductManagement : EProduct
    {
        List<EProduct> productList = new List<EProduct>();
        List<EStocks> stockList = new List<EStocks>();
        int productId = 0;
        public ProductManagement(string name, string desc, float rate)
        {
            name = ProductName;
            desc = Description;
            rate = ProductRate;
        }

        public BaseReturn<EProduct> AddProduct(EProduct product)
        {
            var productData = new BaseReturn<EProduct>();
            try
            {
                if (!productList.Contains(product))
                {
                    productList.Add(new EProduct
                    {
                        ProductId = productId + 1,
                        ProductName = product.ProductName,
                        Description = product.Description,
                        ProductRate = product.ProductRate,
                        ProductAdded = DateTime.Now
                    });

                    productData.Data = product;
                    productData.Success = true;
                    productData.Message = "Product added successfully";
                }
                else
                {
                    productData.Success = false;
                    productData.Message = "Product already exists";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("AddProduct Error:", ex);
            }
            return productData;
        }

        public BaseReturn<EProduct> RemoveProduct(EProduct product)
        {
            var productData = new BaseReturn<EProduct>();
            try
            {
                if (productList.Contains(product))
                {
                    productList.Remove(product);

                    productData.Success = true;
                    productData.Message = "Product added successfully";
                }
                else
                {
                    productData.Success = false;
                    productData.Message = "Product already exists";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("RemoveProduct Error:", ex);
            }
            return productData;
        }

        public BaseReturn<List<EProduct>> GetAllProducts()
        {
            var productData = new BaseReturn<List<EProduct>>();
            try
            {
                if (productList.Count > 0)
                {
                    productData.Data = productList;
                    productData.Success = true;
                    productData.Message = "Product added successfully";
                }
                else
                {
                    productData.Success = false;
                    productData.Message = "Product already exists";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAllProducts Error:", ex);
            }
            return productData;
        }

        public BaseReturn<EProduct> UpdateProduct(EProduct product)
        {
            var productData = new BaseReturn<EProduct>();
            try
            {
                if (productList.Contains(product))
                {
                    var index = productList.IndexOf(product);
                    productList.RemoveAt(index);
                    productList.Insert(index, product);

                    productData.Data = product;
                    productData.Success = true;
                    productData.Message = "Product updated successfully";
                }
                else
                {
                    productData.Success = false;
                    productData.Message = "Product does not exists";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateProduct Error:", ex);
            }
            return productData;
        }

        public BaseReturn<EStocks> AddStock(EStocks product)
        {
            var stockData = new BaseReturn<EStocks>();

            try
            {
                if (!stockList.Contains(product))
                {
                    var stockItem = stockList.Find(m => m.ProductName == product.ProductName);
                    stockData.Data = stockItem;
                    stockData.Success = true;
                    stockData.Message = "Stock for" + product.ProductName + "found";
                }
                else
                {
                    stockData.Success = false;
                    stockData.Message = "Stock for the product already exists";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetProductStock Error:", ex);
            }
            return stockData;
        }

        public BaseReturn<EStocks> GetProductStock(EStocks product)
        {
            var stockData = new BaseReturn<EStocks>();

            try
            {
                if (stockList.Contains(product))
                {
                    var stockItem = stockList.Find(m => m.ProductName == product.ProductName);
                    stockData.Data = stockItem;
                    stockData.Success = true;
                    stockData.Message = "Stock for" + product.ProductName + "found";
                }
                else
                {
                    stockData.Success = false;
                    stockData.Message = "Stock for" + product.ProductName + "not found";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetProductStock Error:", ex);
            }
            return stockData;
        }

        public BaseReturn<EStocks> UpdateStock(EStocks product)
        {
            var stockData = new BaseReturn<EStocks>();

            try
            {
                if (stockList.Contains(product))
                {
                    var index = stockList.IndexOf(product);
                    stockList.RemoveAt(index);
                    stockList.Insert(index, product);

                    stockData.Success = true;
                    stockData.Message = "Stock updated successfully";
                }
                else
                {
                    stockData.Success = false;
                    stockData.Message = "Stock updation failed";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateStock Error:", ex);
            }
            return stockData;
        }

        public BaseReturn<EStocks> RemoveStock(EStocks product)
        {
            var productData = new BaseReturn<EStocks>();
            try
            {
                if (stockList.Contains(product))
                {
                    stockList.Remove(product);

                    productData.Success = true;
                    productData.Message = "Stock removed successfully";
                }
                else
                {
                    productData.Success = false;
                    productData.Message = "Stock does not exists";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("RemoveStock Error:", ex);
            }
            return productData;
        }

        public BaseReturn<List<EStocks>> GetReport(EStocks report)
        {
            var reportData = new BaseReturn<List<EStocks>>();

            try
            {
                var startIndex = stockList.IndexOf(stockList.FirstOrDefault(m => m.FromDate == report.FromDate && m.ProductName == report.ProductName));
                var endIndex = stockList.IndexOf(stockList.FirstOrDefault(m => m.FromDate == report.ToDate && m.ProductName == report.ProductName));
                var getReportData = stockList.GetRange(startIndex, (endIndex - startIndex));

                reportData.Data = getReportData;
                reportData.Success = true;
                reportData.Message = "Report fetched successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetReport Error:", ex);
            }
            return reportData;
        }
    }
}