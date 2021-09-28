using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperation.Queries.GetActor
{
    public class GetActorsQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<ActorsViewModel> Handle()
        {
            var actorList = _dbContext.Actors.Where(x=>x.Status==true).Include(x => x.StarringMovies).ToList();

            List<ActorsViewModel> vm = _mapper.Map<List<ActorsViewModel>>(actorList);
            return vm;
        }
    }
    public class ActorsViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public List<Movie> StarringMovies { get; set; }
    }
}