using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ReviewsRepo : Repo, IRepo<Reviews, int, bool>
    {
        public bool Create(Reviews obj)
        {
            db.Reviews.Add(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Reviews.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Reviews> Read()
        {
            return db.Reviews.ToList();
        }

        public Reviews Read(int id)
        {
            return db.Reviews.Find(id);
        }

        public bool Update(Reviews obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
