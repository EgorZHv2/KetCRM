using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.DTOs.Email
{
    public interface EmailRequest
    {
        Task SendAsync(EmailRequest request);
    }
}
