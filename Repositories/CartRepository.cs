using BussinessObject.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CartRepository : ICartRepository
    {
        public void CreateCart(Cart cart) =>  CartDAO.CreateCart(cart);
        

        public void DeleteCart(Cart cart) => CartDAO.DeleteCart(cart);
        

        public Cart GetCartByUserId(int UserId) => CartDAO.GetCartByUserId(UserId);
        

        public List<Cart> GetCarts() => CartDAO.GetCarts();
        

        public void UpdateCart(Cart cart) => CartDAO.UpdateCart(cart);
        
    }
}
