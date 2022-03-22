using System;
using System.Collections.Generic;

namespace KetCRM.Domain.Entities
{
    public partial class Specialization
    {
        public Specialization()
        {
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
