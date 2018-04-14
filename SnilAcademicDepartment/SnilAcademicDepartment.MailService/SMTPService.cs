using System;
using System.Net.Mail;

namespace SnilAcademicDepartment.MailService
{
    /// <summary>
    /// SMTP Service for sending the confirmation link to new user.
    /// </summary>
    public sealed class SMTPService
    {
        public void SendEmail(MailMessage message)
        {
            ArgumentValidation(message);
            SendMail(message);
        }

        private static void ArgumentValidation(MailMessage message)
        {
            if (message.To.Count == 0)
                throw new ArgumentNullException("message", "Address doesn't exist in this mail.");

            if (string.IsNullOrEmpty(message.Body))
                throw new ArgumentNullException("message", "Mail body is null or empty.");

            if (string.IsNullOrEmpty(message.Subject))
                throw new ArgumentNullException("message", "Mail subject is null or empty.");
        }

        private void SendMail(MailMessage mailMessage)
        {
            using (var smtpClient = new SmtpClient())
            {
                try
                {
                    smtpClient.Send(mailMessage);
                }
                catch (SmtpFailedRecipientsException ex)
                {
                    var args = new SmtpEventArgs(ex);
                    //TODO: For logging this exception
                }
                catch (SmtpException ex)
                {
                    var args = new SmtpEventArgs(ex);
                    //TODO: For logging this exception
                }
            }
        }

    }
}
