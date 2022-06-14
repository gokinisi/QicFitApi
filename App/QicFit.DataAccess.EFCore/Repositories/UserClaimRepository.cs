
using Common.DataAccess.EFCore;
using QicFit.Entities.System;

namespace QicFit.DataAccess.EFCore
{
    public class UserClaimRepository : BaseUserClaimRepository<UserClaim, QicFitDataContext>
    {
        public UserClaimRepository(QicFitDataContext context) : base(context)
        {
        }
    }
}
