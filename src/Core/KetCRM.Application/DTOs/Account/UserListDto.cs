﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.DTOs.Account
{
    public class UserListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Roles { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string LastLogin { get; set; }
    }
}