using BussinessObject.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        public void CreateCartItem(CartItem cartItem) => CartItemDAO.CreateCartItem(cartItem);
        

        public void DeleteCartItem(CartItem cartItem) => CartItemDAO.DeleteCartItem(cartItem);
        

        public List<CartItem> GetCartItems() => CartItemDAO.GetCartItems();
        
        public CartItem GetCartItemsByProductId(int productId) => CartItemDAO.GetCartItemsByProductId(productId);
       

        public void UpdateCartItem(CartItem cartItem) => CartItemDAO.UpdateCartItem(cartItem);
        
    }
}
