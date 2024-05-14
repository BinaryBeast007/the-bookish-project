using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class categoryRepo : Repo, IRepo<Categories, int, bool>
    {
        public bool Create(Categories obj)
        {
            db.Categories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Categories.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Categories> Read()
        {
            return db.Categories.ToList();
        }

        public Categories Read(int id)
        {
            return db.Categories.Find(id);
        }

        public bool Update(Categories obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
