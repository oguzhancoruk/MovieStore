using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.MovieOperation.Commands.DeleteMovies
{
    public class DeleteMoviesCommand
    {   
        public int MoviesId{get;set;}
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DeleteMoviesCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var movies =_context.Movies.SingleOrDefault(x=>x.MovieId==MoviesId);
            if(movies is null)
            throw new InvalidOperationException("Silinecek Film Bulunamadı");
            _context.Movies.Remove(movies);
            _context.SaveChanges();

        }
    }
}