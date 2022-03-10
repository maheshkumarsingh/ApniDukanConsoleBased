using DAOLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductBL
    {
        IProductDAO productDAO = new ProductDAO();

        public List<Product> ReadAllProduct()
        {
            return productDAO.ReadAllProduct();
        }

        public List<Product> SortProductsByCategory(string cat, List<Product> productList)
        {
            List<Product> list = new List<Product>();
            foreach (Product item in productList)
                if(item.ProductType.Equals(cat))
                    list.Add(item);
            return list;
        }

       
    }
}
