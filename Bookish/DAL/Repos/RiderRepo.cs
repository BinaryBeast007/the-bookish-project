using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class RiderRepo : Repo, IRepo<Rider, int, bool>
    {
        public bool Create(Rider obj)
        {
            db.Riders.Add(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Riders.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Rider> Read()
        {
            return db.Riders.ToList();
        }

        public Rider Read(int id)
        {
            return db.Riders.Find(id);
        }

        public bool Update(Rider obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
