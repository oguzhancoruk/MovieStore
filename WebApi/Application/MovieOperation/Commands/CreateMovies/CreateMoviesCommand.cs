using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperation.Commands.CreateMovies
{
    public class CreateMoviesCommand

    
    {   
        public CreateMoviesModel Model{get;set;}
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMoviesCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var  movie=_context.Movies.SingleOrDefault(x=>x.MovieName==Model.MovieName);
            if(movie is not null)
             throw new InvalidOperationException("Film Zaten Mevcut.");
             movie=_mapper.Map<Movie>(Model);
             _context.Movies.Add(movie);
             _context.SaveChanges();

        }
    public class CreateMoviesModel
    {
        public string MovieName{get;set;}
        public int MovieGenreId { get; set; }
        public int MovieDirectorId { get; set; }
        public double MoviePrice { get; set; }
        public DateTime MovieDate{get;set;}
    }

    }

}