using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Model;
using DataAccessLayer;

namespace Repositories
{
	public class SellerRepository : ISellerRepostory
	{
		public void AddSeller(Seller seller) => SellerDAO.Instance.AddSeller(seller);	
		

		public void DeleteSeller(int seller) => SellerDAO.Instance.DeleteSeller(seller);
		

		public List<Seller> GetAllSeller() => SellerDAO.Instance.GetAllSeller();
		
		public Seller GetSellerByID(int seller) => SellerDAO.Instance.GetSellerByID(seller);
		
		public void UpdateSeller(Seller seller) => SellerDAO.Instance.UpdateSeller(seller);
		
	}
}
