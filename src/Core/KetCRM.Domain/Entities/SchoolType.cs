using System;
using System.Collections.Generic;

namespace KetCRM.Domain.Entities
{
    public partial class SchoolType
    {
        public SchoolType()
        {
            StudentInfos = new HashSet<StudentInfo>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<StudentInfo> StudentInfos { get; set; }
    }
}
