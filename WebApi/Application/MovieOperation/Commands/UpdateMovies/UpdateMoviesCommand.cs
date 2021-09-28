using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.MovieOperation.Commands.UpdateMovies
{
    public class UpdateMoviesCommand
    {  
        public int MovieId { get; set; }
        public UpdateMovieModel Model {get;set;}        
         private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateMoviesCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
             var movie = _context.Movies.SingleOrDefault(x => x.MovieId == MovieId);
            if (movie is null || movie.Status==false)
                throw new InvalidOperationException("Güncellenecek film bulunamadı.");

            movie.MovieGenreId = Model.MovieGenreId != default ? Model.MovieGenreId : movie.MovieGenreId;
            movie.MovieDirectorId = Model.MovieDirectorId != default ? Model.MovieDirectorId : movie.MovieDirectorId;
            movie.MovieName = Model.MovieName != default ? Model.MovieName : movie.MovieName;
            movie.MoviePrice = Model.MoviePrice != default ? Model.MoviePrice : movie.MoviePrice;
            _context.SaveChanges();

        }


    }
    public class UpdateMovieModel
    {
        public string MovieName { get; set; }
        public int MovieGenreId { get; set; }
        public int MovieDirectorId { get; set; }
        public double MoviePrice { get; set; }

    }
}