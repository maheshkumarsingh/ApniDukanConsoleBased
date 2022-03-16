using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLayer
{
    public interface ICartDAO
    {
        int InsertIntoCart(Cart cart);

        List<Cart> ReadCartByUserEmailID(string userID);
    }
}
