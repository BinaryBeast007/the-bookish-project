using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BooksService

    { 
    public static List<BooksDTO> Get()
    {
        var data = DataAccessFactory.BookData().Read();
        var cfg = new MapperConfiguration(c =>
        {
            c.CreateMap<Books, BooksDTO>();
        });

        var mapper = new Mapper(cfg);
        return mapper.Map<List<BooksDTO>>(data);
    }


    public static BooksDTO Get(int id)
    {
        var data = DataAccessFactory.BookData().Read(id);
        var cfg = new MapperConfiguration(c =>
        {
            c.CreateMap<Books, BooksDTO>();
        });
        var mapper = new Mapper(cfg);
        var mapped = mapper.Map<BooksDTO>(data);
        return mapped;
    }


    public static bool Add(BooksDTO c)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<BooksDTO, Books>();
        });
        var mapper = new Mapper(config);
        var data = mapper.Map<Books>(c);
        return DataAccessFactory.BookData().Create(data);

    }

    public static BooksDTO Delete(int id)
    {
        var data = DataAccessFactory.BookData().Delete(id);

        return null;
    }

    public static BooksDTO Update(int id)
    {
        var data = DataAccessFactory.BookData().Read(id);



        var cfg = new MapperConfiguration(c =>
        {
            c.CreateMap<Books, BooksDTO>();
        });
        var mapper = new Mapper(cfg);
        var mapped = mapper.Map<BooksDTO>(data);
        return mapped;
    }







    public static bool Update(BooksDTO p)
    {
        var rdata = DataAccessFactory.BookData().Read();
        var exdata = DataAccessFactory.BookData().Read(p.Id);

        if (exdata != null)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BooksDTO, Books>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<Books>(p);


            return DataAccessFactory.BookData().Update(data);
        }


        return false;
    }
}

  
}
