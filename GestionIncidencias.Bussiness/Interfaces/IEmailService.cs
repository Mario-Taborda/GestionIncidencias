using System.Threading.Tasks;

namespace GestionIncidencias.Bussiness.Interfaces
{
    public interface IEmailService
    {
        Task EnviarCorreoAsync(string destinatario, string asunto, string mensajeHtml);
    }
}