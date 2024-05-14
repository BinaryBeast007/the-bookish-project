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
    public class AuthorService
    {
        public static List<AuthosDTO> Get()
        {
            var data = DataAccessFactory.AuthorData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Authors, AuthosDTO>();
            });

            var mapper = new Mapper(cfg);
            return mapper.Map<List<AuthosDTO>>(data);
        }


        public static AuthosDTO Get(int id)
        {
            var data = DataAccessFactory.AuthorData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Authors, AuthosDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AuthosDTO>(data);
            return mapped;
        }


        public static bool Add(AuthosDTO c)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthosDTO, Authors>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Authors>(c);
            return DataAccessFactory.AuthorData().Create(data);

        }

        public static AuthosDTO Delete(int id)
        {
            var data = DataAccessFactory.AuthorData().Delete(id);

            return null;
        }

        public static AuthosDTO Update(int id)
        {
            var data = DataAccessFactory.AuthorData().Read(id);



            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Authors, AuthosDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AuthosDTO>(data);
            return mapped;
        }







        public static bool Update(AuthosDTO p)
        {
            var rdata = DataAccessFactory.AuthorData().Read();
            var exdata = DataAccessFactory.AuthorData().Read(p.Id);

            if (exdata != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AuthosDTO, Authors>();
                });

                var mapper = new Mapper(config);
                var data = mapper.Map<Authors>(p);


                return DataAccessFactory.AuthorData().Update(data);
            }


            return false;
        }
    }
}