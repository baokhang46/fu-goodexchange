using BussinessObject.Model;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CartService: ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository) 
        {
            _cartRepository = cartRepository;
        }

        public void CreateCart(Cart cart)
        {
            _cartRepository.CreateCart(cart);
        }

        public void DeleteCart(Cart cart)
        {
            _cartRepository.DeleteCart(cart);
        }

        public Cart GetCartByUserId(int UserId)
        {
            return _cartRepository.GetCartByUserId(UserId); 
        }

        public List<Cart> GetCarts()
        {
          return  _cartRepository.GetCarts();
        }

        public void UpdateCart(Cart cart)
        {
            _cartRepository.UpdateCart(cart);
        }
    }
}
