using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.Models
{
    public class CreatePersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int? PersonType { get; set; } //Типов персоны пока нет, так что пока можно null
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Snils { get; set; }
        public string? InsuranceNumber { get; set; }
        public string? PassportSeries { get; set; }
        public string? PassportNumber { get; set; }
        public DateTime? PassportDate { get; set; }
        public string? PassportPlace { get; set; }
        public string? Comment { get; set; }
        public byte[]? Photo { get; set; }
    }
}
