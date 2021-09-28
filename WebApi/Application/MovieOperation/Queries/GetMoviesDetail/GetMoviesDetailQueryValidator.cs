using FluentValidation;

namespace WebApi.Application.MovieOperation.GetMovies.GetMoviesDetail
{
    public class GetMoviesDetailQueryValidator:AbstractValidator<GetMoviesDetailQuery>
    {
        public GetMoviesDetailQueryValidator()
        {
            RuleFor(query=>query.MovieID).GreaterThan(0); 
        }
    }
}