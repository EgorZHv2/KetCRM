using System;
using System.Collections.Generic;

namespace KetCRM.Domain.Entities
{
    public partial class PersonType
    {
        public PersonType()
        {
            People = new HashSet<Person>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? AccesLevelId { get; set; }

        public virtual AccessLevel? AccesLevel { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
