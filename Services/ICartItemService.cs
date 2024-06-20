using BussinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICartItemService
    {
        List<CartItem> GetCartItems();
        void CreateCartItem(CartItem cartItem);
        void UpdateCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);
        CartItem GetCartItemsByProductId(int productId);
    }
}
