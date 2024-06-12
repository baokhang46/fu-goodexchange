using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Model;
using Repositories;

namespace Services
{
	public class OrderService : IOrderService
	{
		private IOrderRepository orderRepository = null;
		public void DeleteOrder(int order)
		{
			orderRepository.DeleteOrder(order);
		}

		public List<Order> GetAllOrder()
		{
			return orderRepository.GetAllOrder();
		}

		public Order GetOrderByID(int order)
		{
			return orderRepository.GetOrderByID(order);
		}
	}
}
