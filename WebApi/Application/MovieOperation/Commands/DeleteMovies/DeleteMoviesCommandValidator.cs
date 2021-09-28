using FluentValidation;

namespace WebApi.Application.MovieOperation.Commands.DeleteMovies
{
    public class DeleteMoviesCommandValidator:AbstractValidator<DeleteMoviesCommand>
    {
        public DeleteMoviesCommandValidator()
        {
            RuleFor(command=>command.MoviesId).GreaterThan(0);
        }
    }
}