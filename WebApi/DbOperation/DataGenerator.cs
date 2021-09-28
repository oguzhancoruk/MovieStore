using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Dboperation
{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if(context.Movies.Any())
                {
                    return;
                }
                context.Actors.AddRange(
                    new Actor{Name="Oğuzhan",SurName="Çoruk" },
                    new Actor{Name="Kaan",SurName="Taşyaran"},
                    new Actor{Name="Barış",SurName="Can"},
                    new Actor{Name="Ahmet",SurName="Anıl"}

                );
                context.Customers.AddRange(
                    new Customer{Name="Mustafa",SurName="Yumlu",Email="MYumlu@gmail.com",Password="616161"},
                    new Customer{Name="Zeki",SurName="Yavru",Email="ZY@gmail.com",Password="61616161"},
                    new Customer{Name="Kamil",SurName="Ahmet",Email="KAhmet@gmail.com",Password="6161616161"}
                );
                context.Directors.AddRange(
                    new Director{DirectorName="Fatih",DirectorSurname="Terim"},
                    new Director{DirectorName="Abdullah",DirectorSurname="Avcı"},
                    new Director{DirectorName="Sergen",DirectorSurname="Yalçın"},
                    new Director{DirectorName="Ergin",DirectorSurname="Ataman"}
                );
                context.Genres.AddRange(
                    new Genre{Name="Futbol"},
                    new Genre{Name="Basketbol"}
                );
                context.Movies.AddRange(
                    new Movie{MovieName="Trabzonspor",MovieActorId=1,MovieDirectorId=2,MovieGenreId=1,MoviePrice=12.00,MovieDate=new DateTime(10/10/2010)},
                    new Movie{MovieName="Galatasaray",MovieActorId=2,MovieDirectorId=1,MovieGenreId=1,MoviePrice=11.11,MovieDate=new DateTime(11/11/2000)},
                    new Movie{MovieName="Anadolu Efes",MovieActorId=3,MovieDirectorId=4,MovieGenreId=2,MoviePrice=23.00,MovieDate=new DateTime(12/11/2021)}
                );
                context.Orders.AddRange(
                    new Order { CustomerId = 1, MovieId = 1, OrderDate = new DateTime(1990, 05, 20), Price = 12.00 },
                    new Order { CustomerId = 2, MovieId = 2, OrderDate = new DateTime(1980, 02, 10), Price = 11.11 },
                    new Order { CustomerId = 3, MovieId = 3, OrderDate = new DateTime(2000, 10, 12), Price = 23.00 }
                );

                context.SaveChanges();


            }


        }
    }
}