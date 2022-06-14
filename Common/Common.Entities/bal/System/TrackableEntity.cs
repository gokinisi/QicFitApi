
using Common.Entities;

namespace QicFit.Entities.System
{
    public abstract class TrackableEntity : BaseTrackableEntity
    {
        public virtual User CreatedByUser { get; set; }
        public virtual User UpdatedByUser { get; set; }
    }
}
