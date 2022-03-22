using System;
using System.Collections.Generic;

namespace KetCRM.Domain.Entities
{
    public partial class SchoolEducationType
    {
        public SchoolEducationType()
        {
            StudentInfos = new HashSet<StudentInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<StudentInfo> StudentInfos { get; set; }
    }
}
