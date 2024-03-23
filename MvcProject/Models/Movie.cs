using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcProject.Data;

namespace MvcProject.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        public int Cinema_Id { get; set; }

       [ ForeignKey("Cinema_Id")]
        public Cinema Cinema_Movie { get; set; }

        public int Producer_Id { get; set; }
        [ForeignKey("Producer_Id")]
        public Producer Producer_Movie { get; set; }

        public List<Actor_Movie> Actor_Movies { get; set; }

    }
}

