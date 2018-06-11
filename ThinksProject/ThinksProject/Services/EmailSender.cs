﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace ThinksProject.Services
{
	// This class is used by the application to send email for account confirmation and password reset.
	// For more details see https://go.microsoft.com/fwlink/?LinkID=532713
	public class EmailSender : IEmailSender
	{
		private readonly IConfiguration _configuration;

		public EmailSender(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task SendEmailAsync(string email, string subject, string message)
		{
			var emailMessage = new MimeMessage();
			var login = _configuration.GetConnectionString("LoginEmailService");
			var pass = _configuration.GetConnectionString("PasswordEmailService");


			emailMessage.From.Add(new MailboxAddress("Администрация сайта", login));
			emailMessage.To.Add(new MailboxAddress("", email));
			emailMessage.Subject = subject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
				Text = message
			};

			using (var client = new SmtpClient())
			{
				await client.ConnectAsync("smtp.yandex.ru", 25, false);
				await client.AuthenticateAsync(login, pass);
				await client.SendAsync(emailMessage);

				await client.DisconnectAsync(true);
			}
		}
	}

}
