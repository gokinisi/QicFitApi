using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.DTO
{
    public class SystemMessageDTO
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
