using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RiderService
    {
        public static List<RiderDTO> Get()
        {
            var data = DataAccessFactory.RiderData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Rider, RiderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<RiderDTO>>(data);
            return mapped;
        }

        public static RiderDTO Get(int id)
        {
            var data = DataAccessFactory.RiderData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Rider, RiderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<RiderDTO>(data);
            return mapped;
        }

        public static bool Create(RiderDTO Rider)
        {
            if (Rider == null)
            {
                throw new ArgumentNullException(nameof(Rider), "Rider object cannot be null");
            }

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<RiderDTO, Rider>();
            });
            var mapper = new Mapper(cfg);
            var RiderEntity = mapper.Map<Rider>(Rider);

            var created = DataAccessFactory.RiderData().Create(RiderEntity);

            return created;
        }

        public static bool Update(RiderDTO Rider)
        {
            if (Rider == null)
            {
                throw new ArgumentNullException(nameof(Rider), "Rider object cannot be null");
            }

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<RiderDTO, Rider>();
            });
            var mapper = new Mapper(cfg);
            var RiderEntity = mapper.Map<Rider>(Rider);

            var created = DataAccessFactory.RiderData().Update(RiderEntity);

            return created;
        }

        public static bool Delete(int id)
        {
            var res = DataAccessFactory.RiderData().Delete(id);
            return res;
        }
    }
}
