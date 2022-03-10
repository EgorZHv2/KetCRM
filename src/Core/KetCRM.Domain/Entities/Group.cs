using System;
using System.Collections.Generic;

namespace KetCRM.Domain.Entities
{
    public partial class Group
    {
        public Group()
        {
            StudentInfos = new HashSet<StudentInfo>();
        }

        public int Id { get; set; }
        public int? SpecializationId { get; set; }
        public bool? AfterEleven { get; set; }
        public int? FormOfEducationId { get; set; }
        public int? PersonTeacherId { get; set; }
        public int? PersonElderId { get; set; }
        public int? DepartmentId { get; set; }
        public string? CourseNumber { get; set; }
        public string? GroupNumber { get; set; }

        public virtual Department? Department { get; set; }
        public virtual FormsOfEducation? FormOfEducation { get; set; }
        public virtual Person? PersonTeacher { get; set; }
        public virtual Specialization? Specialization { get; set; }
        public virtual ICollection<StudentInfo> StudentInfos { get; set; }
    }
}
