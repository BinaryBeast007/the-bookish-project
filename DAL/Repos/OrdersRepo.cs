using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;

namespace DAL.Repos
{
    public class OrdersRepo : Repo, IRepo<Orders, int, bool>
    {
        public bool Create(Orders obj)
        {
            db.Orders.Add(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Orders.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Orders> Read()
        {
            return db.Orders.ToList();
        }

        public Orders Read(int id)
        {
            return db.Orders.Find(id);
        }

        public bool Update(Orders obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<Orders> GetOrdersByBuyerId(int buyerId)
        {
            return db.Orders.Where(order => order.BuyerId == buyerId).ToList();
        }
    }
}
