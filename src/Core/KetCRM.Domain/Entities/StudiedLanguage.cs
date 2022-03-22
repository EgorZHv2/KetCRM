using System;
using System.Collections.Generic;

namespace KetCRM.Domain.Entities
{
    public partial class StudiedLanguage
    {
        public StudiedLanguage()
        {
            StudentInfos = new HashSet<StudentInfo>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<StudentInfo> StudentInfos { get; set; }
    }
}
