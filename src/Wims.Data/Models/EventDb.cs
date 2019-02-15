using System;
using System.Collections.Generic;
using Wims.Domain;

namespace Wims.Data.Models
{
    public class EventDb : BaseEntity
    {
        public string Name { get; set; }

        public EventType EventType { get; set; }

        public VenueDb Location { get; set; }

        public DateTime startDateTimeInUtc { get; set; }

        public DateTime endDateTimeInUtc { get; set; }

        public List<SevadaarDb> Sevadaars { get; set; }
    }
}
