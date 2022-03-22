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

        public Guid Id { get; set; }
        public int? SpecializationId { get; set; }
        public bool? AfterEleven { get; set; }
        public Guid? FormOfEducationId { get; set; }
        public Guid? PersonTeacherId { get; set; }
        public Guid? PersonElderId { get; set; }
        public Guid? DepartmentId { get; set; }
        public string? CourseNumber { get; set; }
        public string? GroupNumber { get; set; }

        public virtual Department? Department { get; set; }
        public virtual FormsOfEducation? FormOfEducation { get; set; }
        public virtual Person? PersonTeacher { get; set; }
        public virtual Specialization? Specialization { get; set; }
        public virtual ICollection<StudentInfo> StudentInfos { get; set; }
    }
}
