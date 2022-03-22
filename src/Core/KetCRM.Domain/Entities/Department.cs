using System;
using System.Collections.Generic;

namespace KetCRM.Domain.Entities
{
    public partial class Department
    {
        public Department()
        {
            Groups = new HashSet<Group>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public Guid? PersonTeacherId { get; set; }

        public virtual Person? PersonTeacher { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
