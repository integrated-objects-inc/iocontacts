using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;

namespace iocontacts
{
    internal static class Email
    {
        internal static void SendEmail(int userSessionKey, string mailTo, string subject, string body)
        {
            const string functionName = "SendEmail()";
            
            string smtpServer = Common.SMTPServer();
            string emailUser = Common.EmailUser();
            string emailPassword = Common.EmailPassword();
            string emailFrom = Common.EmailFrom();

            if (smtpServer.Length == 0 || emailFrom.Length == 0 || emailUser.Length == 0 || emailPassword.Length == 0)
                return;

            SmtpClient smtpClient = new System.Net.Mail.SmtpClient(smtpServer);
            MailMessage mailMessage;
            System.Net.NetworkCredential smtpUserInfo = new System.Net.NetworkCredential(emailUser, emailPassword);

            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = smtpUserInfo;
            mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = false;
            mailMessage.From = new System.Net.Mail.MailAddress(emailFrom);
            mailMessage.To.Add(mailTo);
            
            try
            {
                smtpClient.Send(mailMessage);
                return;
            }
            catch (Exception ex)
            {
                new io.Data.Return<bool>(io.Constants.FAILURE, ex.Message, "Email runtime error", false).LogResult(Constants.SystemInstallKey, Constants.SystemKey, Constants.AppKey, userSessionKey, 1, functionName);
            }
        }
    }
}
