
namespace Common.Entities
{
    public class UserPhoto : BaseEntity
    {
        public byte[] Image { get; set; }

        public virtual BaseUser User { get; set; }
    }
}
