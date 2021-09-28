using FluentValidation;

namespace WebApi.Application.ActorOperation.Commands.DeleteActor
{
 public class DeleteActorCommandValidator :AbstractValidator<DeleteActorCommand>
 {
     public DeleteActorCommandValidator()
     {
         RuleFor(x=>x.ActorId).GreaterThan(0);
     }
 }   
}