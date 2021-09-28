using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperation.Queries.GetMovies
{
    public class GetMoviesQuery
    {   
        public int MovieID {get;set;}
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      public List<MoviesViewModel> Handle()
         {
          var movielist=_context.Movies.Include(x=>x.Actors).Include(y=>y.Director).Include(z=>z.Genre)
            .Where(movie=>movie.MovieId==MovieID && movie.Status==true).SingleOrDefault();
          
          List<MoviesViewModel> vn= _mapper.Map<List<MoviesViewModel>>(movielist);
         
           
          return vn;
         }
    } 

     public class MoviesViewModel
    {
        public string MovieName{get;set;}
        public string Genre { get; set; }
        public string Director { get; set; }
        public DateTime MovieDate { get; set; }
        public List<Actor> Actors { get; set; }
        public double MoviePrice { get; set; }
    }
}