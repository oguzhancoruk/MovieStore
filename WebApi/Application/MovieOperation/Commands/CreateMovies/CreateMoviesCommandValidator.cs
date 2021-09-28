using System;
using FluentValidation;

namespace WebApi.Application.MovieOperation.Commands.CreateMovies
{
    
    public class CreateMoviesCommandValidator:AbstractValidator<CreateMoviesCommand>
    {
        public CreateMoviesCommandValidator()
        {
            RuleFor(command=>command.Model.MovieName).NotEmpty().MinimumLength(3);
            RuleFor(command=>command.Model.MovieGenreId).GreaterThan(0);
            RuleFor(command=>command.Model.MoviePrice).GreaterThan(0.00);
            RuleFor(command=>command.Model.MovieDirectorId).GreaterThan(0);
            RuleFor(command=>command.Model.MovieDate).NotEmpty().LessThan(DateTime.Now.Date);   
        }
    }
}