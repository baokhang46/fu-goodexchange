using BussinessObject.Model;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BuyerService: IBuyerService
    {
        private readonly IBuyerRepository _buyerRepository;
        public BuyerService(IBuyerRepository buyerRepository) 
        {
            _buyerRepository = buyerRepository;
        }

        public void AddBuyer(Buyer buyer)
        {
           _buyerRepository.AddBuyer(buyer);
        }

        public void DeleteBuyer(int buyer)
        {
           _buyerRepository.DeleteBuyer(buyer);
        }

        public List<Buyer> GetAllBuyer()
        {
          return  _buyerRepository.GetAllBuyer();
        }

        public Buyer GetBuyerByID(int buyer)
        {
           return _buyerRepository.GetBuyerByID(buyer);
        }

        public void UpdateBuyer(Buyer buyer)
        {
            _buyerRepository.UpdateBuyer(buyer);
        }
    }
}
