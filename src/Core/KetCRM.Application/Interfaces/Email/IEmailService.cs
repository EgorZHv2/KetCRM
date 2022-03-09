using KetCRM.Application.DTOs.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.Interfaces.Email
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
