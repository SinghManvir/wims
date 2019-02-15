using System;

namespace Wims.Domain
{
    public class Venue
    {
        public string Name;

        public VenueType VenueType { get; set; }

        public Address Address { get; set; }
    }
}
