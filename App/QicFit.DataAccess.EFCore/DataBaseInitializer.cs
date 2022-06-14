
using Common.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace QicFit.DataAccess.EFCore
{
    public class DataBaseInitializer : IDataBaseInitializer
    {
        private QicFitDataContext context;
        public DataBaseInitializer(QicFitDataContext context)
        {
            this.context = context;
        }

        public void Initialize()
        {
            using (context)
            {
                // turn off timeout for initial seeding
                context.Database.SetCommandTimeout(System.TimeSpan.FromDays(1));
                // check data base version and migrate / seed if needed
                context.Database.Migrate();
            }
        }
    }
}
