
using QicFit.Entities;
using System.Collections.Generic;

namespace Common.Entities
{
    public class Settings : BaseEntity
    {
        public string ThemeName { get; set; }
        
        public virtual BaseUser User { get; set; }
    }
}