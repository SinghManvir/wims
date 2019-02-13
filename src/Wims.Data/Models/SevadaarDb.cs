using Wims.Domain;

namespace Wims.Data.Models
{
    public class SevadaarDb : BaseEntity
    {
        public string Name { get; set; }

        public string ProfilePicture { get; set; }

        public SevaType SevaType { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }
    }
}
