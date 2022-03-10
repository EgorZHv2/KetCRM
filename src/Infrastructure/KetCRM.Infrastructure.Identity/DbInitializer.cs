using KetCRM.Infrastructure.Identity.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Infrastructure.Identity
{
    public class DbInitializer
    {
        public static void Initialize(IdentityContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
