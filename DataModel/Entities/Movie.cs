using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    }
}
