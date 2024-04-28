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
    public class OrderService
    {
        public static List<OrdersDTO> Get()
        {
            var data = DataAccessFactory.OrderData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Orders, OrdersDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrdersDTO>>(data);
            return mapped;
        }

        public static OrdersDTO Get(int id)
        {
            var data = DataAccessFactory.OrderData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Orders, OrdersDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrdersDTO>(data);
            return mapped;
        }

        public static bool Create(OrdersDTO Orders)
        {
            if (Orders == null)
            {
                throw new ArgumentNullException(nameof(Orders), "Orders object cannot be null");
            }

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OrdersDTO, Orders>();
            });
            var mapper = new Mapper(cfg);
            var OrdersEntity = mapper.Map<Orders>(Orders);

            var created = DataAccessFactory.OrderData().Create(OrdersEntity);

            return created;
        }

        public static bool Update(OrdersDTO Orders)
        {
            if (Orders == null)
            {
                throw new ArgumentNullException(nameof(Orders), "Orders object cannot be null");
            }

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OrdersDTO, Orders>();
            });
            var mapper = new Mapper(cfg);
            var OrdersEntity = mapper.Map<Orders>(Orders);

            var created = DataAccessFactory.OrderData().Update(OrdersEntity);

            return created;
        }

        public static bool Delete(int id)
        {
            var res = DataAccessFactory.OrderData().Delete(id);
            return res;
        }
    }
}
