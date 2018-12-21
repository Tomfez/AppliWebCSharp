using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime ReleasedDate { get; set; }

        public List<Comment> Comment { get; set; }
        public List<MovieActor> Actors { get; set; }
        public Person Director { get; set; }
    }
}
