using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GestionIncidencias.Web.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identidadAnonima = new ClaimsIdentity();
            var usuario = new ClaimsPrincipal(identidadAnonima);

            return Task.FromResult(new AuthenticationState(usuario));
        }
    }
}