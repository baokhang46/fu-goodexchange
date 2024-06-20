using BussinessObject.Model;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public void CreateCartItem(CartItem cartItem)
        {
            _cartItemRepository.CreateCartItem(cartItem);
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            _cartItemRepository.DeleteCartItem(cartItem);
        }

        public List<CartItem> GetCartItems()
        {
           return _cartItemRepository.GetCartItems();
        }

        public CartItem GetCartItemsByProductId(int productId)
        {
            return _cartItemRepository.GetCartItemsByProductId(productId);
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _cartItemRepository.UpdateCartItem(cartItem);
        }
    }
}
