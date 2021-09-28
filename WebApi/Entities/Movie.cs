using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Movie 
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int MovieId{get;set;}
        public string MovieName{get;set;}
        public DateTime MovieDate { get; set; }
        public int MovieGenreId{get;set;}
        public virtual Genre Genre { get; set; }
        public int MovieDirectorId { get; set; }
        public virtual Director Director { get; set; }
        public virtual List<Actor> Actors { get; set; }
        public int  MovieActorId { get; set; }
        public double MoviePrice { get; set; }
        public bool Status { get; set; } = true;


    }
}