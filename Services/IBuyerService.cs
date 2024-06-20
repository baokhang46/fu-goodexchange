using BussinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBuyerService
    {
        List<Buyer> GetAllBuyer();
        void AddBuyer(Buyer buyer);

        Buyer GetBuyerByID(int buyer);

        void DeleteBuyer(int buyer);

        void UpdateBuyer(Buyer buyer);
    }
}
