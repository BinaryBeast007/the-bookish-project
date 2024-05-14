using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class Booksrepo : Repo, IRepo<Books, int, bool>
    {
        public bool Create(Books obj)
        {
            db.Books.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Books.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Books> Read()
        {
            return db.Books.ToList();
        }

        public Books Read(int id)
        {
            return db.Books.Find(id);
        }

        public bool Update(Books obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
