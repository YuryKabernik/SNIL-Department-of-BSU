using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SnilAcademicDepartment.Common.ConfigManagerAdapter;
using MailService.Properties;

namespace SnilAcademicDepartment.MailService
{
	/// <summary>
	/// SMTP Service for sending the confirmation link to new user.
	/// </summary>
	public sealed class SMTPService
	{
		private readonly ISNILConfigurationManager _configManager;

		public SMTPService(ISNILConfigurationManager configManager)
		{
			this._configManager = configManager;
		}

		public async Task SendEmailAsync(MailMessage message)
		{
			ArgumentValidation(message);
			await SendMailAsync(message);
		}

		private async Task SendMailAsync(MailMessage mailMessage)
		{
			var host = await this._configManager.GetConfigValueStringAsync(SnilMailingConfigurationKeys.HostName);
			var port = await this._configManager.GetConfigValueIntAsync(SnilMailingConfigurationKeys.PortValue);
			var login = await this._configManager.GetConfigValueStringAsync(SnilMailingConfigurationKeys.CredentialsLogin);
			var password = await this._configManager.GetConfigValueStringAsync(SnilMailingConfigurationKeys.CredentialsPassword);

			using (var smtpClient = new SmtpClient
			{
				Host = host,
				Port = port,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(userName: login, password: password),
			})
			{
				try
				{
					smtpClient.EnableSsl = true;
					await smtpClient.SendMailAsync(mailMessage);
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

		private void ArgumentValidation(MailMessage message)
		{
			if (message.To.Count == 0)
				throw new ArgumentNullException("message", "Address doesn't exist in this mail.");

			if (string.IsNullOrEmpty(message.Body))
				throw new ArgumentNullException("message", "Mail body is null or empty.");

			if (string.IsNullOrEmpty(message.Subject))
				throw new ArgumentNullException("message", "Mail subject is null or empty.");
		}
	}
}
