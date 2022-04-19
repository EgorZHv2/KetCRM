using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetCRM.Application.Models;

namespace KetCRM.Application.Common.Interfaces
{
    public interface IPersonService
    {
        Task<Result> CreatePerson(CreatePersonModel model);
    }
}
