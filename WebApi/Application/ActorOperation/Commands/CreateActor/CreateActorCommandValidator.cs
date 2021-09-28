using FluentValidation;

namespace WebApi.Application.ActorOperation.Commands.CreateActor
{
    public class CreateActorCommandValidator:AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
             RuleFor(x => x.actorModel.Name).MinimumLength(2);
             RuleFor(x => x.actorModel.SurName).MinimumLength(2);
        }
    }
}