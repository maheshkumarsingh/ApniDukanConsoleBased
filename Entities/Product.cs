using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductType { get; set; }

        public string ProductName { get; set; }

        public Int64 ProductPrice { get; set; }

        public DateTime ProductMFGDate { get; set; }
        public DateTime ProductExpiryDate { get; set; }

        public override string ToString()
        {
            string data = String.Format("\n{0,-15} {1,-30} {2,-30} {3,-20} {4,-30} {5,-30}",
                                        "Product ID", "Product Type", "Product Name", "Product Price", "Product Manufacture Date", "Product Expiry Date");
            data+= String.Format("\n{0,-15} {1,-30} {2,-30} {3,-20} {4,-30} {5,-30}", ProductID,
                                        ProductType, ProductName, ProductPrice, ProductMFGDate.ToString("dd MMMM yyyy"), ProductExpiryDate.ToString("dd MMMM yyyy"));
            return data;
        }
    }
}
