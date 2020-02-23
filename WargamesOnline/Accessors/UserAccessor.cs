using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PBEMGlory.Models.dbModels;

namespace PBEMGlory.Accessors
{
    /// <summary>
    /// A helper for various user related access
    /// </summary>
    public class UserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>Get Claim</summary>
        public string GetClaim(string ClaimName)
        {
            if (_httpContextAccessor.HttpContext.User != null)
                if (_httpContextAccessor.HttpContext.User.Claims != null)
                    if (_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimName) != null)
                        return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimName).Value.ToString();
            return default(string);
        }

        /// <summary>Get role of current user</summary>
        public string CurrentRole()
        {
            if (_httpContextAccessor.HttpContext.User != null)
                if (_httpContextAccessor.HttpContext.User.Claims != null)
                    if (_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role) != null)
                        return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            return default(string);
        }

        /// <summary>
        /// Create a claims principal to centralize how claims are created for user logon
        /// </summary>
        public static ClaimsPrincipal ClaimsPrincipal(User user)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, "User"),
                        new Claim("UserID", user.Id.ToString()),
                        new Claim("Name", user.UserName)
                    }, CookieAuthenticationDefaults.AuthenticationScheme));
        }
    }
}
