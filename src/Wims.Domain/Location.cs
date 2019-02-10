using System;

namespace Wims.Domain
{
    public class Location
    {
        public string Name;

        public LocationType LocationType { get; set; }

        public Address Address { get; set; }
    }
}
