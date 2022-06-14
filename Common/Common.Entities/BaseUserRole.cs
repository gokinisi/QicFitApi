
namespace Common.Entities
{
    public abstract class BaseUserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual BaseUser User { get; set; }
        public virtual BaseRole Role { get; set; }
    }
}
