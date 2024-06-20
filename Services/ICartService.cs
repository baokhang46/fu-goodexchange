using BussinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICartService
    {
        List<Cart> GetCarts();
        void CreateCart(Cart cart);
        void DeleteCart(Cart cart);
        void UpdateCart(Cart cart);
        Cart GetCartByUserId(int UserId);
    }
}
