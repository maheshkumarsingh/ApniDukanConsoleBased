using DAOLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CartBL
    {
        ICartDAO cartDAO = new CartDAO();
        public int InsertIntoCart(Cart cart)
        {
            return cartDAO.InsertIntoCart(cart);
        }

        public List<Cart> ReadCartByUserEmailID(string userID) => cartDAO.ReadCartByUserEmailID(userID);
    }
}
