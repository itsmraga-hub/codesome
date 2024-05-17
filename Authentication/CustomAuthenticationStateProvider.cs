using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Security.Claims;

namespace codesome.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;

        private ClaimsPrincipal _user = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
                if (userSession == null)
                    return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
                var claimsPrincipal = new ClaimsPrincipal(
                                            new ClaimsIdentity(
                                                new[] {
                                                new Claim(ClaimTypes.Name, userSession.Username),
                                                new Claim(ClaimTypes.Email, userSession.Email),
                                                new Claim(ClaimTypes.MobilePhone, userSession.PhoneNumber),
                                                }, "apiauth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception)
            {
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            }
        }

        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
            if (userSession == null)
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _user;
            }
            else
            {

                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(
                                        new ClaimsIdentity(
                                            new[]
                        {
                    new Claim(ClaimTypes.Name, userSession.Username),
                    new Claim(ClaimTypes.Email, userSession.Email),
                    new Claim(ClaimTypes.MobilePhone, userSession.PhoneNumber),
                        }, "apiauth"));
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
