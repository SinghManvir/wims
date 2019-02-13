using System;
using System.Collections.Generic;
using System.Text;

namespace Wims.Data.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime createdDateUtc { get; set; }

        public DateTime modifiedDateUtc { get; set; }
    }
}
