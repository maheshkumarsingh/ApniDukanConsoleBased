using DAOLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class ProductBL
    {
        IProductDAO productDAO = new ProductDAO();

        public List<Product> ReadAllProduct()
        {
            return productDAO.ReadAllProduct();
        }

        public Product SearchProductByID(int id)
        {
            return productDAO.SearchProductByID(id);
        }

        public IEnumerable<Product> SortProductsByCategory(string cat, List<Product> productList)
        {
            IEnumerable<Product> orderByCategory =
                productList.Where(p=> p.ProductType==cat);
            return orderByCategory;
        }

        public IEnumerable<Product> SortProductsByCategory(List<Product> productList)
        {
            IEnumerable<Product> orderByCategory = 
                productList.OrderBy(p=>p.ProductType);
            return orderByCategory;
        }



        public IEnumerable<Product> SortProductsByPrice(List<Product> productList)
        {
            //return productDAO.SortProductsByPrice(productList);
            IEnumerable<Product> orderByPrice =
                productList.OrderBy(p => p.ProductPrice);
            return orderByPrice;
        }

        public IEnumerable<Product> SortProductsByMFGDate(List<Product> productList)
        {
            IEnumerable<Product> orderByMFGDate =
                productList.OrderBy(p => p.ProductMFGDate);
            return orderByMFGDate;
        }

        public int AddProduct(Product product) => productDAO.AddProduct(product);
        public int UpdateProductByID(int id, Int64 price) => productDAO.UpdateProductByID(id, price);

        public int DeleteProductByID(int id) => productDAO.DeleteProductByID(id);
    }
}
