using Wims.Domain;

namespace Wims.Data.Models
{
    public class LocationDb
    {
        public string Name;

        public LocationType LocationType { get; set; }

        public AddressDb Address { get; set; }
    }
}
