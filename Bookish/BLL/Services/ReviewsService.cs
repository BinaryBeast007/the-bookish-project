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
    public class ReviewsService
    {
        public static List<ReviewsDTO> Get()
        {
            var data = DataAccessFactory.ReviewData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Reviews, ReviewsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ReviewsDTO>>(data);
            return mapped;
        }

        public static ReviewsDTO Get(int id)
        {
            var data = DataAccessFactory.ReviewData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Reviews, ReviewsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ReviewsDTO>(data);
            return mapped;
        }

        public static bool Create(ReviewsDTO Reviews)
        {
            if (Reviews == null)
            {
                throw new ArgumentNullException(nameof(Reviews), "Reviews object cannot be null");
            }

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ReviewsDTO, Reviews>();
            });
            var mapper = new Mapper(cfg);
            var ReviewsEntity = mapper.Map<Reviews>(Reviews);

            var created = DataAccessFactory.ReviewData().Create(ReviewsEntity);

            return created;
        }

        public static bool Update(ReviewsDTO Reviews)
        {
            if (Reviews == null)
            {
                throw new ArgumentNullException(nameof(Reviews), "Reviews object cannot be null");
            }

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ReviewsDTO, Reviews>();
            });
            var mapper = new Mapper(cfg);
            var ReviewsEntity = mapper.Map<Reviews>(Reviews);

            var created = DataAccessFactory.ReviewData().Update(ReviewsEntity);

            return created;
        }

        public static bool Delete(int id)
        {
            var res = DataAccessFactory.ReviewData().Delete(id);
            return res;
        }
    }
}
