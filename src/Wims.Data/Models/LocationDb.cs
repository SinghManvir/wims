﻿using Wims.Domain;

namespace Wims.Data.Models
{
    public class LocationDb : BaseEntity
    {
        public string Name;

        public LocationType LocationType { get; set; }

        public AddressDb Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }
    }
}
