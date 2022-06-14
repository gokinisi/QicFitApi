
using Common.DataAccess.EFCore;
using QicFit.Entities.System;

namespace QicFit.DataAccess.EFCore
{
    public class IdentityUserRepository : BaseIdentityUserRepository<User, QicFitDataContext>
    {
        public IdentityUserRepository(QicFitDataContext context) : base(context)
        {
        }
    }
}
