using BussinessObject.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        public void AddBuyer(Buyer buyer) => BuyerDAO.Instance.AddBuyer(buyer);


        public void DeleteBuyer(int buyer) => BuyerDAO.Instance.DeleteBuyer(buyer);


        public List<Buyer> GetAllBuyer() => BuyerDAO.Instance.GetAllBuyer();

        public Buyer GetBuyerByID(int buyer) => BuyerDAO.Instance.GetBuyerByID(buyer);

        public void UpdateBuyer(Buyer buyer) => BuyerDAO.Instance.UpdateBuyer(buyer);
    }
}
