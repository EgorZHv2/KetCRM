using KetCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KetCRM.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<AccessLevel> AccessLevels { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<FormsOfEducation> FormsOfEducations { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<PersonType> PersonTypes { get; set; }
        DbSet<SchoolEducationType> SchoolEducationTypes { get; set; }
        DbSet<SchoolType> SchoolTypes { get; set; }
        DbSet<Specialization> Specializations { get; set; }
        DbSet<StudentInfo> StudentInfos { get; set; }
        DbSet<StudentStatus> StudentStatuses { get; set; }
        DbSet<StudiedLanguage> StudiedLanguages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}