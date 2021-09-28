using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperation.Commands.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorModel actorModel{get;set;}
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var actor= _context.Actors.SingleOrDefault(x=>x.Name==actorModel.Name);
            if(actor is not null)
            throw new InvalidOperationException("Actor Zaten Mevcut ");
            actor= new Actor();
            actor = _mapper.Map<Actor>(actor);
            _context.Actors.Add(actor);
            _context.SaveChanges();

        }
    }

    public class CreateActorModel
    {

        public string Name { get; set; }
        public string SurName { get; set; }
        
    }

}