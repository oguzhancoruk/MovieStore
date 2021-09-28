using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperation.GetMovies.GetMoviesDetail
{
    public class GetMoviesDetailQuery
    {   
        public int MovieID {get;set;}
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMoviesDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public MoviesDetailViewModel Handle()
        {   
            var movie=_context.Movies.Include(x=>x.Actors).Include(y=>y.Director).Include(z=>z.Genre)
            .Where(movie=>movie.MovieId==MovieID && movie.Status==true).SingleOrDefault();
            if(movie is null)
            throw new InvalidOperationException("Film Bulunamadı");
            MoviesDetailViewModel viewModel=_mapper.Map<MoviesDetailViewModel>(movie);
            return viewModel; 

        }
    }
    public class MoviesDetailViewModel
    {
        public string MovieName{get;set;}
        public string Genre { get; set; }
        public string Director { get; set; }
        public DateTime MovieDate { get; set; }
        public List<Actor> Actors { get; set; }
        public double MoviePrice { get; set; }
    }

}
