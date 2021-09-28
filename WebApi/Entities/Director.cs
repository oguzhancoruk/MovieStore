using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Director
    {    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public string DirectorSurname { get; set; }
        public virtual List<Movie> DirectedMovies { get; set; }
        public bool Status { get; set; } = true;
    }
}