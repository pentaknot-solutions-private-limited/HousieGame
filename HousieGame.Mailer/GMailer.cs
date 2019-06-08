using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace HousieGame.Mailer
{
    public class GMailer
    {
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public string EmailAttachment { get; set; }

        static GMailer()
        {
            GmailHost = "smtp.gmail.com";
            GmailPort = 587; // Gmail can use ports 25, 465 & 587; but must be 25 for medium trust environment.
            GmailSSL = true;
            GmailUsername = "noreply.thegamingbirds@gmail.com";
            GmailPassword = "chirag@birds";
        }
        public string Send()
        {
            string strMsg = string.Empty;
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);
                smtp.Port = GmailPort;
                smtp.Host = GmailHost;
                smtp.EnableSsl = GmailSSL;
                smtp.TargetName = "STARTTLS/smtp.gmail.com";
                using (var message = new MailMessage(GmailUsername, ToEmail))
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = IsHtml;
                    Attachment data = new Attachment(EmailAttachment, MediaTypeNames.Application.Octet);
                    message.Attachments.Add(data);
                    smtp.Send(message);
                }
                strMsg = "Success";
            }
            catch (Exception ex)
            {
                strMsg = "Fail : " + ex.ToString();
            }
            return strMsg;
        }

    }
}
