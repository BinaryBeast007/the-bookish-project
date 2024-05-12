using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;

namespace DAL.Repos
{
    public class BuyerRepo : Repo, IRepo<Buyer, int, bool>, IAuth<bool>
    {
        public bool Authenticate(string email, string password)
        {
            var data = db.Buyers.FirstOrDefault(u=>u.Email.Equals(email) && u.Password.Equals(password));
            if (data != null) return true;
            return false;
        }

        public bool Create(Buyer obj)
        {
            db.Buyers.Add(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Buyers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Buyer> Read()
        {
            return db.Buyers.ToList();
        }

        public Buyer Read(int id)
        {
            return db.Buyers.Find(id);
        }

        public bool Update(Buyer obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
