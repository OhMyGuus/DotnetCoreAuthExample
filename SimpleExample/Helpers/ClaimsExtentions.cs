using Microsoft.EntityFrameworkCore;
using SimpleExample.Models;
using SimpleExample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace SimpleExample.Helpers
{
    public static class ClaimsExtentions
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            int userid = 0;
            if (int.TryParse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value, out userid))
            {
                return userid;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }

        public static async Task<User> GetUserAsync(this ClaimsPrincipal principal, IUserRepository userRepository)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            var user = userRepository.GetUser(principal.GetUserId());
            if (user == null)
            {
                throw new Exception("User not found..");
            }
            return user;
        }

        public static bool IsAdmin(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            return principal.IsInRole("Admin");

        }
    }
}
