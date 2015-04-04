using SocialNetwork.WebUI.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

namespace SocialNetwork.WebUI.Infrastructure.Concrete
{
    public class EmailVerifyProvider : IVerifyProvider
    {
        public bool IsApproved(string username)
        {
            var user = Membership.GetUser(username);
            if (user != null)
            {
                if (user.IsApproved == false)
                {
                    SendEmail(username);
                    return true;
                }
            }
            return false;
        }

        public bool Verify(string username, string secretCode)
        {
            var user = Membership.GetUser(username);
            if (user != null)
            {
                if (user.IsApproved == false && user.Comment == secretCode)
                {
                    user.IsApproved = true;
                    user.Comment = Guid.NewGuid().ToString();
                    Membership.UpdateUser(user);
                    return Membership.GetUser(username).IsApproved;
                }
            }
            return false;
        }

        private void SendEmail(string username)
        {
            var user = Membership.GetUser(username);
            user.Comment = Guid.NewGuid().ToString();
            Membership.UpdateUser(user);
            string link = "http://localhost:1705//Verify/Verify" +
                            "/" +
                            user.UserName +
                            "/" +
                            user.Comment;

            MailMessage sendingMessage = new MailMessage
            (
                "BNTU.SocialNetwork@gmail.com",
                user.Email,
                "Activation",
                "<a href = \"" + link + "\"> Activate Social Network account</a>"
            );
            sendingMessage.IsBodyHtml = true;
            SendMail(sendingMessage, "smtp.gmail.com", "bntu.socialnetwork@gmail.com", "DFyufhtibnNJ");

        }

        /// <summary>
        /// Sends a message with using SMTP Server.
        /// </summary>
        /// <param name="message">Message contains: sender's email, addressee's email, mails content.</param>
        /// <param name="host">SMTP Server hostname or IP address.</param>
        /// <param name="username">Username for account on SMTP Server. Defaults sender's email.</param>
        /// <param name="password">Password for account on SMTP Server.</param>
        /// <param name="port">The port used for SMTP transactions.</param>
        /// Credentials options should follow before the initialization of Credentials.
        /// <example> For example:
        /// <code>
        ///     smtpClient.UseDefaultCredentials = false;
        ///     smtpClient.EnableSsl = true;
        ///     smtpClient.Credentials = new NetworkCredential(username, password);
        /// </code>
        /// </example>
        /// See more: <see cref="http://msdn.microsoft.com/library/system.net.mail.smtpclient.aspx"/>
        public void SendMail(MailMessage message, string host, string username, string password, int port = 587)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Host = host;
                smtpClient.Port = port;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(username, password);
                try
                {
                    smtpClient.Send(message);
                }
                catch (System.Net.Mail.SmtpException e)
                {
                    string errorMessage = e.Message;
                }
            }
        }

    }
}