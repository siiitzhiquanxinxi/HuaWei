using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
namespace DTcms.Common
{
    public class SendMail
    {

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="Subject">邮件名称</param>
        /// <param name="Body">邮件内容</param>
        /// <param name="MailTo">发给谁</param>
        /// <param name="Psd">密码</param>
        /// <param name="Host">邮件host地址</param>
        /// <param name="SendName">发送人</param>
        /// <param name="Sendaddr">发送地址</param>
        public static void Send(string Subject, string Body, string MailTo, string Psd, string Host, string SendName, string Sendaddr)
        {
            MailAddress from = new MailAddress(Sendaddr, SendName); //邮件的发件人
            MailMessage mail = new MailMessage();
            mail.Subject = Subject;
            mail.From = from;
            string address = "";
            string displayName = "";
            string[] mailNames = (MailTo + ";").Split(';');
            foreach (string name in mailNames)
            {
                if (name != string.Empty)
                {
                    if (name.IndexOf('<') > 0)
                    {
                        displayName = name.Substring(0, name.IndexOf('<'));
                        address = name.Substring(name.IndexOf('<') + 1).Replace('>', ' ');
                    }
                    else
                    {
                        displayName = string.Empty;
                        address = name.Substring(name.IndexOf('<') + 1).Replace('>', ' ');
                    }
                    mail.To.Add(new MailAddress(address, displayName));
                }
            }
            mail.Body = Body;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Host = Host;
            client.Port = 25;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(Sendaddr.Split('@')[0],Psd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(mail);
        }

        public static string CreateTimeoutTestMessage(string server)
        {
            string Success = "发送成功";
            try
            {
                string _to = "1035092449@qq.com";
                string _from = "young-20@163.com";
                string _subject = "Using the new SMTP client.";
                string _body = @"Using this new feature, you can send an e-mail message from an application very easily.";
                MailMessage message = new MailMessage();
                message.From = new MailAddress(_from);
                //可以利用MailMessage.To.Add方法增加要发送的邮件地址
                message.To.Add(new MailAddress("652105072@qq.com"));
                message.To.Add(new MailAddress(_to));
                message.Subject = _subject;
                message.Body = _body;
                //添加附件
                Attachment a = new Attachment(@"C:/Users/Administrator/Desktop/smtpclient.rar");
                message.Attachments.Add(a);
                //设置邮箱的地址或IP
                SmtpClient client = new SmtpClient(server);
                //设置邮箱端口，pop3端口:110, smtp端口是:25
                client.Port = 25;
                //设置超时时间
                client.Timeout = 9999;
                //要输入邮箱用户名与密码
                client.Credentials = new NetworkCredential("young-20@163.com", "******");
                client.Send(message);
            }
            catch (Exception ex)
            {
                Success = ex.ToString();
            }
            return Success;
        }
    }
}
