
namespace Common.Entities
{
    public abstract class BaseUserClaim : BaseEntity
    {
        public int UserId { get; set; }

        public virtual BaseUser User { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
    }
}
