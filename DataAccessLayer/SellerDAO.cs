using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Model;

namespace DataAccessLayer
{
	public class SellerDAO
	{
		private static SellerDAO instance = null;

		public SellerDAO()
		{
		}



		public static SellerDAO Instance
		{

			get
			{
				if (instance == null)
				{
					instance = new SellerDAO();
				}
				return instance;
			}

		}

		public List<Seller> GetAllSeller()
		{
			try
			{
				var dbContent = new FugoodExchangeContext();
				return dbContent.Sellers.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Seller GetSellerByID(int seller)
		{
			try
			{
				var dbContent = new FugoodExchangeContext();
				return dbContent.Sellers.SingleOrDefault(m => m.SellerId.Equals(seller));
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AddSeller(Seller seller)
		{
			try
			{
				var dbContent = new FugoodExchangeContext();
				Seller sellerProfile = GetSellerByID(seller.SellerId);
				if (sellerProfile == null)
				{
					dbContent.Sellers.Add(seller);
					dbContent.SaveChanges();
				}
				else
				{
					throw new Exception("SellerID has existed !");
				}

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		public void DeleteSeller(int seller)
		{
			try
			{
				var dbContent = new FugoodExchangeContext();
				Seller sellerProfile = GetSellerByID(seller);
				if (seller != null)
				{
					dbContent.Sellers.Remove(sellerProfile);
					dbContent.SaveChanges();
				}

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		public void UpdateSeller(Seller seller)
		{
			var dbContent = new FugoodExchangeContext();

			if (seller != null)
			{
				dbContent.Sellers.Update(seller);
				dbContent.SaveChanges();
			}
			else
			{
				throw new Exception("SellerID hasn't existed !");
			}
		}

	
	}
}
