
using System;

namespace Common.Entities
{
    public abstract class BaseTrackableEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int CreatedByUserId { get; set; }
        public int UpdatedByUserId { get; set; }
    }
}
