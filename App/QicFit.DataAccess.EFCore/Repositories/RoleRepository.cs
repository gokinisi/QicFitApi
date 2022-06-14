
using Common.DataAccess.EFCore;
using QicFit.Entities.System;

namespace QicFit.DataAccess.EFCore
{
    public class RoleRepository : BaseRoleRepository<Role, QicFitDataContext>
    {
        public RoleRepository(QicFitDataContext context) : base(context)
        {
        }
    }
}
