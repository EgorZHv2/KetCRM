using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Identity.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name)
            : base($"Сущность \"{name}\" not found.") { }
    }
}
