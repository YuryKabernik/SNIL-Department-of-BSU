using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{
    internal class SmtpEventArgs : EventArgs
    {
        public Exception ExceptionExemplar { get; }

        public SmtpEventArgs(Exception exception)
        {
            this.ExceptionExemplar = exception;
        }
    }
}
