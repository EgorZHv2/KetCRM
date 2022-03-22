using System;
using System.Collections.Generic;

namespace KetCRM.Domain.Entities
{
    public partial class Person
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
            Departments = new HashSet<Department>();
            Groups = new HashSet<Group>();
            StudentInfos = new HashSet<StudentInfo>();
            Representatives = new HashSet<Person>();
            Students = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? PersonType { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SNILS { get; set; }
        public string? InsuranceNumber { get; set; }
        public string? PassportSeries { get; set; }
        public string? PassportNumber { get; set; }
        public DateTime? PassportDate { get; set; }
        public string? PassportPlace { get; set; }
        public string? Comment { get; set; }
        public byte[]? Photo { get; set; }

        public virtual PersonType? PersonTypeNavigation { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<StudentInfo> StudentInfos { get; set; }

        public virtual ICollection<Person> Representatives { get; set; }
        public virtual ICollection<Person> Students { get; set; }
    }
}
