using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace BigOn.Domain.AppCode.Extensions
{
    public static partial class Extension
    {
        static public bool SendMail(this IConfiguration configuration, string toEmail, string textBody, string textSubject)
        {
            try
            {
               


                SmtpClient client = new SmtpClient(
                    configuration["emailAccount:smtpServer"],
                    Convert.ToInt32(configuration["emailAccount:smtpPort"]));
                client.Credentials = new NetworkCredential
                    (configuration["emailAccount:userName"], 
                    configuration["emailAccount:password"]);
                client.EnableSsl = true;

                MailAddress from = new MailAddress
                    (configuration["emailAccount:userName"], 
                    configuration["emailAccount:displayName"]);

                MailAddress to = new MailAddress(toEmail);

                MailMessage message = new MailMessage(from, to);
                message.Subject = textSubject;
                message.Body = textBody;

                message.IsBodyHtml = true;

                client.Send(message);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        
        }

    }


    
}
