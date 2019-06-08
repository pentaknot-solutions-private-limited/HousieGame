using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace HousieGame.Mailer
{
    public class WebMailer
    {
        public static string MailUsername { get; set; }
        public static string MailPassword { get; set; }
        public static string MailHost { get; set; }
        public static int MailPort { get; set; }
        public static bool MailSSL { get; set; }
        public string ToEmail { get; set; }
        public string CCEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public System.IO.Stream EmailAttachment { get; set; }
        public List<System.IO.Stream> emailAttachmentsList { get; set; }
        public string FileName { get; set; }
        public List<string> fileNameList { get; set; }
        static WebMailer()
        {
            MailUsername = "scorpjonas@gmail.com";
            MailPassword = "@24Scorp.";
            MailHost = "smtp.gmail.com";
            MailPort = 587;
            MailSSL = true;
        }
        public string Send()
        {
            string strMsg = string.Empty;
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(MailUsername, MailPassword);
                smtp.Port = MailPort;
                smtp.Host = MailHost;
                smtp.EnableSsl = MailSSL;
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(MailUsername);
                    foreach (string address in ToEmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (!string.IsNullOrEmpty(address))
                            message.To.Add(address);
                    }
                    foreach (string address in CCEmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (!string.IsNullOrEmpty(address))
                            message.CC.Add(address);
                    }
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = IsHtml;
                    if (FileName != null)
                    {
                        message.Attachments.Add(new Attachment(EmailAttachment, FileName));
                    }
                    try
                    {
                        if (fileNameList.Count > 0)
                        {
                            for (int i = 0; i < fileNameList.Count; i++)
                            {
                                message.Attachments.Add(new Attachment(emailAttachmentsList[i], fileNameList[i]));
                            }
                        }
                    }
                    catch (Exception fileex)
                    {
                        strMsg = " " + fileex.ToString();
                    }
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
