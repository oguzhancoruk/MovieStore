   
using FluentValidation;

namespace WebApi.Application.ActorOperation.Queries.GetActorDetail
{
    public class GetActorDetailQueryValidator : AbstractValidator<GetActorDetailQuery>
    {
        public GetActorDetailQueryValidator()
        {
            RuleFor(x => x.ActorId).GreaterThan(0);
        }
    }
}