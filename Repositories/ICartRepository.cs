using BussinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICartRepository
    {
        List<Cart> GetCarts();
        void CreateCart(Cart cart);
        void DeleteCart(Cart cart);
        void UpdateCart(Cart cart);
        Cart GetCartByUserId(int UserId);
    }
}
