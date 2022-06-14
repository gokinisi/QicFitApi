using System.Collections.Generic;

namespace Common.Entities
{
    public abstract class BaseRole : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<BaseUserRole> UserRoles { get; set; }
    }
}
