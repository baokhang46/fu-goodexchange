﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Model;

namespace Repositories
{
	public interface IOrderRepository
	{
		List<Order> GetAllOrder();
		
		Order GetOrderByID(int order);

		void DeleteOrder(int order);

	}
}
