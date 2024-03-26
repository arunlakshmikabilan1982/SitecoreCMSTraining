using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Sitecore.Demo.Foundation.SitecoreExtensions.Helpers
{
    public static class EmailHelper
    {
        public static void SendEmail(
            SmtpClient smtpServer,
            string emailFrom,             
            List<string> emailsTo, 
            List<string> emailsCC,
            List<Attachment> attachments, 
            string subject, 
            string body)
        {
            var mail = new MailMessage();

            if(!string.IsNullOrEmpty(emailFrom))
                mail.From = new MailAddress(emailFrom);

            InitEmailTo(emailsTo, ref mail);
            InitEmailCC(emailsCC, ref mail);
            InitAttachment(attachments, ref mail);

            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = HttpUtility.HtmlDecode(body);
            smtpServer.Send(mail);

        }

        static void InitEmailTo(List<string> emailsTo, ref MailMessage mail)
        {
            if (emailsTo != null && emailsTo.Any())
            {
                foreach (var email in emailsTo)
                {
                    if (!string.IsNullOrEmpty(email))
                        mail.To.Add(email);
                }
            }
        }
        static void InitEmailCC(List<string> emailsCC, ref MailMessage mail)
        {
            if (emailsCC != null && emailsCC.Any())
            {
                foreach (var email in emailsCC)
                {
                    if (!string.IsNullOrEmpty(email))
                        mail.CC.Add(email);
                }
            }
        }

        static void InitAttachment(List<Attachment> attachments, ref MailMessage mail)
        {
            if (attachments != null && attachments.Any())
            {
                foreach (var attach in attachments)
                {
                    if (attach != null)
                        mail.Attachments.Add(attach);
                }
            }
        }

        public static SmtpClient InitSMTP(string host, int port, string userName, string password, bool enableSsl = false)
        {
            var smtpServer = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = enableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };
            
            if (!string.IsNullOrEmpty(password))
            {
                smtpServer.UseDefaultCredentials = true;
                smtpServer.Credentials = new NetworkCredential(userName, password);
            }
            else
            {
                smtpServer.UseDefaultCredentials = false;
            }

            return smtpServer;
        }

    }
}
