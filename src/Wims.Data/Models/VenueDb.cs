using Wims.Domain;

namespace Wims.Data.Models
{
    public class VenueDb : BaseEntity
    {
        public string Name { get; set; }

        public VenueType VenueType { get; set; }

        public AddressDb Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }
    }
}
