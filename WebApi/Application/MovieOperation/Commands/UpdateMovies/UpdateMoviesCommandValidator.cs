using FluentValidation;

namespace WebApi.Application.MovieOperation.Commands.UpdateMovies
{
    public class UpdateMoviesCommandValidator:AbstractValidator<UpdateMoviesCommand>
    {
        public UpdateMoviesCommandValidator()
        {
            RuleFor(command=>command.Model.MovieGenreId).GreaterThan(0);
            RuleFor(command=>command.Model.MovieName).NotEmpty().MinimumLength(3);
            RuleFor(command=>command.Model.MoviePrice).GreaterThan(0.00);
            RuleFor(command=>command.Model.MovieDirectorId).GreaterThan(0);

        }
    }
}