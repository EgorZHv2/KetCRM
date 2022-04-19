using KetCRM.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.Common.Interfaces
{
    public interface IStudentService
    {
        Task<Result> CreateStudent(CreateStudentModel model);
    }
}
