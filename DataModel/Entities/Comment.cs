using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }
    }
}
