using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Model;

namespace Services
{
	public interface ISellerService
	{
		List<Seller> GetAllSeller();
		void AddSeller(Seller seller);

		Seller GetSellerByID(int seller);

		void DeleteSeller(int seller);

		void UpdateSeller(Seller seller);
	}
}
