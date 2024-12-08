using OriontaxSync.libs;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace OriontaxSync.Classes
{
    internal class Mail
    {
        private static MailMessage mail = new MailMessage();
        private static SmtpClient smtpClient = new SmtpClient();

        public Mail()
        {
            // Configurações do servidor SMTP
            string smtpServer = ConfigReader.GetConfigValue("mail_host"); // Substitua pelo servidor SMTP do seu provedor
            int smtpPort = int.Parse(ConfigReader.GetConfigValue("mail_port")); // Porta usada para envio de e-mail (pode ser 587 ou 465)
            string senderEmail = ConfigReader.GetConfigValue("mail_user"); // Seu e-mail
            string senderPassword = Funcoes.Decrypt(ConfigReader.GetConfigValue("mail_pwd")); // Sua senha
            string senderFrom = ConfigReader.GetConfigValue("mail_from"); // Email do usuário

            mail.From = new MailAddress(senderEmail, senderFrom);

            // Configurando o cliente SMTP
            smtpClient.Host = smtpServer;
            smtpClient.Port = smtpPort;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true; // Use SSL se o provedor exigir
        }

        public void SendEmailHtml(string subject, string body)
        {
            try
            {

                // Destinatário e detalhes da mensagem
                string recipientEmail = "douglasdev.cn@gmail.com";

                // Criando o objeto MailMessage
                mail.To.Add(recipientEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true; // True se for HTML

                // Enviando o e-mail
                smtpClient.Send(mail);
                Console.WriteLine("E-mail enviado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
            }
        }

        public void SendEmailText(string subject, string body)
        {
            try
            {

                // Destinatário e detalhes da mensagem
                string recipientEmail = "douglasdev.cn@gmail.com";

                // Criando o objeto MailMessage
                mail.To.Add(recipientEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false; // True se for HTML

                // Enviando o e-mail
                smtpClient.Send(mail);
                Console.WriteLine("E-mail enviado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
            }
        }
    }
}
