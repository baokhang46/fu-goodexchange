using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Model;
using Repositories;

namespace Services
{
	public class SellerService : ISellerService
	{
		private ISellerRepostory sellerRepostory = null;
		public void AddSeller(Seller seller)
		{
			sellerRepostory.AddSeller(seller);
		}

		public void DeleteSeller(int seller)
		{
			sellerRepostory.DeleteSeller(seller);
		}

		public List<Seller> GetAllSeller()
		{
			return sellerRepostory.GetAllSeller();
		}

		public Seller GetSellerByID(int seller)
		{
			return sellerRepostory.GetSellerByID(seller);
		}

		public void UpdateSeller(Seller seller)
		{
			sellerRepostory.UpdateSeller(seller);
		}
	}
}
