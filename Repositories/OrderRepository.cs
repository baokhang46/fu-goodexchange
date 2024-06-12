using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Model;
using DataAccessLayer;

namespace Repositories
{
	public class OrderRepository : IOrderRepository
	{
		public void DeleteOrder(int order) => OrderDAO.Instance.DeleteOrder(order);


		public List<Order> GetAllOrder() => OrderDAO.Instance.GetAllOrder();


		public Order GetOrderByID(int order) => OrderDAO.Instance.GetOrderByID(order);
	}	
}
