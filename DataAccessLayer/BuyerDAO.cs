using BussinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BuyerDAO
    {
        private static BuyerDAO instance = null;

        public BuyerDAO()
        {
        }
        public static BuyerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BuyerDAO();
                }
                return instance;
            }

        }

        public List<Buyer> GetAllBuyer()
        {
            try
            {
                var dbContent = new FugoodexchangeContext();
                return dbContent.Buyers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Buyer GetBuyerByID(int buyer)
        {
            try
            {
                var dbContent = new FugoodexchangeContext();
                return dbContent.Buyers.SingleOrDefault(m => m.BuyerId.Equals(buyer));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddBuyer(Buyer buyer)
        {
            try
            {
                var dbContent = new FugoodexchangeContext();
                Buyer BuyerProfile = GetBuyerByID(buyer.BuyerId);
                if (BuyerProfile == null)
                {
                    dbContent.Buyers.Add(buyer);
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

        public void DeleteBuyer(int buyer)
        {
            try
            {
                var dbContent = new FugoodexchangeContext();
                Buyer BuyerProfile = GetBuyerByID(buyer);
                if (buyer != null)
                {
                    dbContent.Buyers.Remove(BuyerProfile);
                    dbContent.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateBuyer(Buyer buyer)
        {
            var dbContent = new FugoodexchangeContext();

            if (buyer != null)
            {
                dbContent.Buyers.Update(buyer);
                dbContent.SaveChanges();
            }
            else
            {
                throw new Exception("BuyerID hasn't existed !");
            }
        }
    }
}
