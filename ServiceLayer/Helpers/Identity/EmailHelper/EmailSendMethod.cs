using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Identity.EmailHelper
{
    public interface IEmailSendMethod
    {
        Task SendPasswordResetLinkWithToken(string passwordResetLink, string toEmail);
    }
    public class EmailSendMethod : IEmailSendMethod
    {
        private readonly GmailInformationsVM _emailInfo;
        public EmailSendMethod(IOptions<GmailInformationsVM> emailInfo)
        {
            _emailInfo = emailInfo.Value;
        }
        public async Task SendPasswordResetLinkWithToken(string passwordResetLink, string toEmail)
        {
            var smtpClient=new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Host = _emailInfo.Host;
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_emailInfo.Email, _emailInfo.Password);
            smtpClient.EnableSsl = true;
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailInfo.Email);
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = "Password Reset Link | Web Plumping";
            mailMessage.Body = $@"<h1>PASSWORD RESET LINK</h1>
                                   <h5>Click <a href='{passwordResetLink}'>HERE</a> to reset your password</h5>";
            mailMessage.IsBodyHtml = true;
            await smtpClient.SendMailAsync(mailMessage);                                  
        }
    }
}
