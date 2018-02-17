using System;

namespace SnilAcademicDepartment.MailService
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
