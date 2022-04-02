using KetCRM.Account.Data;

namespace KetCRM.Identity
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
