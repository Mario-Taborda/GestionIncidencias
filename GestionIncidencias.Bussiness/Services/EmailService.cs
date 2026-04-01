using GestionIncidencias.Bussiness.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace GestionIncidencias.Bussiness.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _correoRemitente = "MarioTaborda1995@gmail.com";
        private readonly string _contrasenaApp = "TU_CONTRASEÑA_DE_APLICACIÓN_AQUI";
        private readonly string _servidorSmtp = "smtp.gmail.com";
        private readonly int _puertoSmtp = 587;
        public async Task EnviarCorreoAsync(string destinatario, string asunto, string mensajeHtml)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Gestión de Incidencias", _correoRemitente));
                email.To.Add(new MailboxAddress("", destinatario));
                email.Subject = asunto;
                var builder = new BodyBuilder { HtmlBody = mensajeHtml };
                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
   
                await smtp.ConnectAsync(_servidorSmtp, _puertoSmtp, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_correoRemitente, _contrasenaApp);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar correo: {ex.Message}");
                throw;
            }
        }
    }
}