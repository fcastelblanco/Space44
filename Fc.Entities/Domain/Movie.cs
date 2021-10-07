using Fc.Entities.Abstractions;

namespace Fc.Entities.Domain
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public string ProductionCompany { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string ActorOne { get; set; }
        public string ActorTwo { get; set; }
        public string ActorThree { get; set; }
        public string Location { get; set; }
    }
}