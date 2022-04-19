using KetCRM.Application.Common.Interfaces;
using KetCRM.Application.Models;
using KetCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.Services
{
    public class StudentService : IStudentService
    {
        private IApplicationDbContext _context;
        public StudentService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Result> CreateStudent(CreateStudentModel model)
        {
            Result result = new Result();

            Person person = new Person()
            {
                Name = model.Name,
                Surname = model.Suranme,
                Patronymic = model.Patronymic,
                Gender = model.Gender,
                BirthDate = model.BirthDate,
                PassportDate = model.PassportDate,
                PassportNumber = model.PassportNumber,
                PersonType = model.PersonType,
                EmailAddress = model.EmailAddress,
                PhoneNumber = model.PhoneNumber,
                Snils = model.Snils,
                InsuranceNumber = model.InsurensNumber,
                PassportSeries = model.PassportSeries,
                PassportPlace = model.PassportPlace,
                Comment = model.Comment,
                Photo = model.Photo,
            };
            StudentInfo studentInfo = new StudentInfo()
            {
                Dormitory = model.Dormitory,
                GraduatedSchool = model.GraduatedSchool,
                GroupId = model.GroupId,
                HasMedal = model.HasMedal,
                HasTwo = model.HasTwo,
                NeedIssuePassCard = model.NeedIssuePassCard,
                PassCardNumber = model.PassCardNumber,
                OnAbudget = model.OnABudget,
                OlimpiadeWinner = model.OlimpiadeWinner,
                PersonId = person.Id,
                SchoolCertificateNumber = model.SchoolCertificateNumber,
                SchoolEducationTypeId = model.SchoolEducationTypeId,
                SchoolTypeId = model.SchoolTypeId,
                StudentRecordBookNumber = model.StudentRecordBookNumber,
                StudentCardNumber = model.StudentCardNumber,
                StudiedLanguageId = model.StudentLanguageId,
                YearOfReleaseFromSchool = model.YearOfReleaseFromSchool,
                WorkExperience = model.WorkExperience,
                TargetedEducation = model.TargetedEducation,
                StudentStatusId = model.StudentStatusId,
                StudentCerteficateNumber = model.StudentCerteficateNumber,
            };

            Re
            
            return result;
        }
    }
}
