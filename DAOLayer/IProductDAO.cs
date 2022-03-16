using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLayer
{
    public interface IProductDAO
    {
        List<Product> ReadAllProduct();

        Product SearchProductByID(int id);
        int AddProduct(Product product);

        int UpdateProductByID(int id, Int64 price);

        int DeleteProductByID(int id);
    }
}
