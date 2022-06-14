using System;
using System.Collections.Generic;
using System.Text;

namespace QicFit.DTO
{
    public class EmailMessageDTO
    {
        public string To { get; set; }
        public string Cc { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string ReplyTo { get; set; }
        public SmtpOption SmtpOptions { get; set; }
        public string UserId { get; set; }
        public bool UseSsl { get; set; }
    }

    public class SmtpOption
    {
        public string Server { get; set; } = string.Empty;
        public int Port { get; set; } = 25;
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool UseSsl { get; set; } = false;
        public bool RequiresAuthentication { get; set; } = false;
    }
}
