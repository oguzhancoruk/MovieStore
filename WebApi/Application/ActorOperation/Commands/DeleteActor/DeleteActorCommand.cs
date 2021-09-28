using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.ActorOperation.Commands.DeleteActor
{
    public class DeleteActorCommand 
    {
        public int ActorId{get;set;}
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DeleteActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var actor=_context.Actors.SingleOrDefault(x=>x.Id==ActorId);
            if(actor is  null)
            throw new InvalidOperationException("Actor Bulunamadı");
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }
    }
}