using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class ProductBL
    {
        IProductDAO productDAO = new ProductDAO();

        public List<Product> ReadAllProduct()
        {
            return productDAO.ReadAllProduct();
        }

        public List<Product> SortProductsByCategory(string cat)
        {

            return null;
        }
    }
}
