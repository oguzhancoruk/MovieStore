using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.ActorOperation.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public int ActorId { get; set; }
        public UpdateActorModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == ActorId);
            if (actor is null || actor.Status == false)
                throw new InvalidOperationException("Güncellenecek oyuncu bulunamadı.");

            actor.Name = Model.Name != default ? Model.Name : actor.Name;
            actor.SurName = Model.SurName != default ? Model.SurName : actor.SurName;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateActorModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}