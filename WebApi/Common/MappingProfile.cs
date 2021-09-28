using AutoMapper;
using WebApi.Application.ActorOperation.Commands.CreateActor;
using WebApi.Application.ActorOperation.Commands.UpdateActor;
using WebApi.Application.ActorOperation.Queries.GetActor;
using WebApi.Application.ActorOperation.Queries.GetActorDetail;
using WebApi.Application.MovieOperation.Commands.UpdateMovies;
using WebApi.Application.MovieOperation.GetMovies.GetMoviesDetail;
using WebApi.Application.MovieOperation.Queries.GetMovies;
using WebApi.Entities;
using static WebApi.Application.MovieOperation.Commands.CreateMovies.CreateMoviesCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMoviesModel, Movie>();
            CreateMap<UpdateMovieModel, Movie>();
            CreateMap<Movie, MoviesDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Director, opt => opt.MapFrom(src => src.Director.DirectorName + " " + src.Director.DirectorSurname)).ForMember(x => x.Actors, opt => opt.MapFrom(src => src.Actors));
            CreateMap<Movie, MoviesViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Director, opt => opt.MapFrom(src => src.Director.DirectorName + " " + src.Director.DirectorSurname)).ForMember(x => x.Actors, opt => opt.MapFrom(src => src.Actors));
           // CreateMap<CreateCustomerModel, Customer>();
           // CreateMap<Customer, CreateCustomerModel>();
            CreateMap<CreateActorModel, Actor>();
            CreateMap<UpdateActorModel, Actor>();
            CreateMap<Actor, ActorDetailViewModel>().ForMember(x => x.StarringMovies, opt => opt.MapFrom(src => src.StarringMovies));
            CreateMap<Actor, ActorsViewModel>().ForMember(x => x.StarringMovies, opt => opt.MapFrom(src => src.StarringMovies));
            //CreateMap<CreateDirectorModel, Director>();
            //CreateMap<UpdateDirectorModel, Director>();
            //CreateMap<Director, DirectorDetailViewModel>().ForMember(x => x.DirectedMovies, opt => opt.MapFrom(src => src.DirectedMovies));
            //CreateMap<Director, DirectorsViewModel>().ForMember(x => x.DirectedMovies, opt => opt.MapFrom(src => src.DirectedMovies));
            //CreateMap<CreateOrderModel, Order>();
            //CreateMap<Order,GetOrdersByCustomerViewModel>().ForMember(x => x.MovieName, opt => opt.MapFrom(src => src.Movie.Name)).ForMember(x => x.CustomerName, opt => opt.MapFrom(src => src.Customer.Name + " " + src.Customer.SurName));
            //CreateMap<Actor, Director>();
        }
    }
}