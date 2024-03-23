﻿using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Movie> MoviesList { get; set; }
    }
}
