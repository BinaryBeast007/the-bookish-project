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
    public class BuyerService
    {
        public static List<BuyerDTO> Get()
        {
            var data = DataAccessFactory.BuyerData().Read();
            var cfg = new MapperConfiguration(c =>{
                c.CreateMap<Buyer, BuyerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BuyerDTO>>(data);
            return mapped;
        }

        public static BuyerDTO Get(int id)
        {
            var data = DataAccessFactory.BuyerData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Buyer, BuyerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BuyerDTO>(data);
            return mapped;
        }

        public static bool Create(BuyerDTO buyer)
        {
            if (buyer == null)
            {
                throw new ArgumentNullException(nameof(buyer), "Buyer object cannot be null");
            }

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<BuyerDTO, Buyer>();
            });
            var mapper = new Mapper(cfg);
            var buyerEntity = mapper.Map<Buyer>(buyer);

            var created = DataAccessFactory.BuyerData().Create(buyerEntity);

            return created;
        }

        public static bool Update(BuyerDTO buyer)
        {
            if (buyer == null)
            {
                throw new ArgumentNullException(nameof(buyer), "Buyer object cannot be null");
            }

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<BuyerDTO, Buyer>();
            });
            var mapper = new Mapper(cfg);
            var buyerEntity = mapper.Map<Buyer>(buyer);

            var created = DataAccessFactory.BuyerData().Update(buyerEntity);

            return created;
        }

        public static bool Delete(int id)
        {
            var res = DataAccessFactory.BuyerData().Delete(id);
            return res;
        }
    }
}
