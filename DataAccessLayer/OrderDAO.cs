using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Model;

namespace DataAccessLayer
{
	public class OrderDAO
	{
		private static OrderDAO instance = null;

		public OrderDAO()
		{
		}



		public static OrderDAO Instance
		{

			get
			{
				if (instance == null)
				{
					instance = new OrderDAO();
				}
				return instance;
			}

		}

		public List<Order> GetAllOrder()
		{
			try
			{
				var dbContent = new FugoodExchangeContext();
				return dbContent.Orders.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Order GetOrderByID(int order)
		{
			try
			{
				var dbContent = new FugoodExchangeContext();
				return dbContent.Orders.SingleOrDefault(m => m.OrderId.Equals(order));
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void DeleteOrder(int order)
		{
			try
			{
				var dbContent = new FugoodExchangeContext();
				Order orderDetail = GetOrderByID(order);
				if (order != null)
				{
					dbContent.Orders.Remove(orderDetail);
					dbContent.SaveChanges();
				}

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}
	}
}
