using Newtonsoft.Json;
using System;

namespace DataModel.Entities
{
    public class MovieActor
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        [JsonIgnore]
        public Movie Movie { get; set; }
        public Person Actor { get; set; }
    }
}