using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GestionIncidencias.Web.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _usuarioActual = new ClaimsPrincipal(new ClaimsIdentity());
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_usuarioActual));
        }
        public void MarcarUsuarioComoLogueado(string email)
        {
            var identidad = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, email)
            }, "AutenticacionPorDefecto");
            _usuarioActual = new ClaimsPrincipal(identidad);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_usuarioActual)));
        }
    }
}