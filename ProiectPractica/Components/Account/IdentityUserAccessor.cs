using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProiectPractica.Entities;
using System.Threading.Tasks;

namespace ProiectPractica.Components.Account
{
    public class IdentityUserAccessor
    {
        private readonly Task<AppUserEntity> _userTask;
        private readonly UserManager<AppUserEntity> _userManager;

        public IdentityUserAccessor(AuthenticationStateProvider authenticationStateProvider, UserManager<AppUserEntity> userManager)
        {
            _userManager = userManager;
            _userTask = GetUserAsync(authenticationStateProvider, userManager);
        }

        private async Task<AppUserEntity> GetUserAsync(AuthenticationStateProvider authenticationStateProvider, UserManager<AppUserEntity> userManager)
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            return await userManager.GetUserAsync(authState.User);
        }

        public Task<AppUserEntity> GetRequiredUser() => _userTask;

        public async ValueTask<AppUserEntity> GetRequiredUserAsync(HttpContext httpContext)
        {
            var user = await GetRequiredUser();
            if (user == null && httpContext.User.Identity?.IsAuthenticated == true)
            {
                user = await _userManager.GetUserAsync(httpContext.User);
            }
            return user ?? throw new InvalidOperationException("User not authenticated.");
        }
    }
}