using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Buyer, int, bool> BuyerData()
        {
            return new BuyerRepo();
        }
        public static IRepo<Orders, int, bool> OrderData()
        {
            return new OrdersRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new BuyerRepo();
        }
    }
}
