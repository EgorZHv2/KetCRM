﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KetCRM.Application.StudentBl.Queries.GetStudentList
{
    public class GetStudentListQuery:IRequest<StudentListVm>
    {
    }
}