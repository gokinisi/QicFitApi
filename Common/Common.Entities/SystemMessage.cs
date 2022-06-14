
using System;

namespace Common.Entities
{
    public class SystemMessage : BaseEntity
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}