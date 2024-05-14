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
        public static IRepo<Authors,int,bool> AuthorData()
        {
            return new AuthorRepo();
        }

        public static IRepo<Books, int, bool> BookData()
        {
            return new Booksrepo();
        }

        public static object BooksData()
        {
            throw new NotImplementedException();
        }

        public static IRepo<Categories, int, bool> CategoryData()
        {
            return new categoryRepo();
        }
    }
}
