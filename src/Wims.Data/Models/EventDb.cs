using System;
using Wims.Domain;

namespace Wims.Data.Models
{
    public class EventDb
    {
        public string Name { get; set; }

        public EventType EventType { get; set; }

        public LocationDb Location { get; set; }

        public DateTime startDateTimeInUtc { get; set; }

        public DateTime endDateTimeInUtc { get; set; }

        public string[] Performers { get; set; }
    }
}
