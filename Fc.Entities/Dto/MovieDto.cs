using System.Text.Json.Serialization;

namespace Fc.Entities.Dto
{
    public class MovieDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("release_year")]
        public string ReleaseYear { get; set; }

        [JsonPropertyName("production_company")]
        public string ProductionCompany { get; set; }

        [JsonPropertyName("director")]
        public string Director { get; set; }

        [JsonPropertyName("writer")]
        public string Writer { get; set; }

        [JsonPropertyName("actor_1")]
        public string ActorOne { get; set; }

        [JsonPropertyName("actor_2")]
        public string ActorTwo { get; set; }

        [JsonPropertyName("actor_3")]
        public string ActorThree { get; set; }

        [JsonPropertyName("locations")]
        public string Location { get; set; }
    }
}
