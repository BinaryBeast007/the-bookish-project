using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AuthorRepo : Repo, IRepo<Authors, int, bool>
    {
        public bool Create(Authors obj)
        {
            db.Authors.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Authors.Remove(ex);
            return db.SaveChanges()>0;
        }

        public List<Authors> Read()
        {
            return db.Authors.ToList();
        }

        public Authors Read(int id)
        {
            return db.Authors.Find(id);
        }

        public bool Update(Authors obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
            
        }
    }
}
