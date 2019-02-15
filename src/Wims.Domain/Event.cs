using System;
using System.Collections.Generic;
using System.Text;

namespace Wims.Domain
{
    public class Event
    {
        public string Name { get; set; }

        public EventType EventType { get; set; }

        public Venue Location { get; set; }

        public DateTime startDateTimeInUtc { get; set; }

        public DateTime endDateTimeInUtc { get; set; }

        public string[] Performers { get; set; }
    }
}
