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
        public static IRepo<Rider, int, bool> RiderData()
        {
            return new RiderRepo();
        }
        public static IRepo<Reviews, int, bool> ReviewData()
        {
            return new ReviewsRepo();
        }
    }
}
