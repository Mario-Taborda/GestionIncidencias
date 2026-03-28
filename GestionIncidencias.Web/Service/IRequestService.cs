namespace GestionIncidencias.Web.Service
{
    public interface IRequestService
    {
        Task<T> GetTAsync<T>(string url);
        Task<T> GetByIdAsync<T>(string url, int id);
        Task<HttpResponseMessage> PostAsync<T>(string url, T model);
        Task<bool> DeleteAsync(string url);
        Task<HttpResponseMessage> PutAsync<T>(string url, T model);
    }
}
