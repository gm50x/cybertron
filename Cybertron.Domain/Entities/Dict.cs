using System;

namespace Cybertron.Domain.Entities
{
    public class Dict
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Description { get; set; }
        public DateTime IncludedAt { get; set; }
        public DateTime AlteredAt { get; set; }
    }
}
