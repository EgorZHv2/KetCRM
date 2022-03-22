using System;
using System.Collections.Generic;

namespace KetCRM.Domain.Entities
{
    public partial class AccessLevel
    {
        public AccessLevel()
        {
            PersonTypes = new HashSet<PersonType>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<PersonType> PersonTypes { get; set; }
    }
}
