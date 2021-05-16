using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data
{
    public class ApplicationDbContextSeed
    {
        public async Task SeedAsync(ApplicationDbContext context, IWebHostEnvironment env,
                    ILogger<ApplicationDbContextSeed> logger, UserManager<IdentityUser> userManager, int? retry = 0)
        {
            int retryForAvaiability = retry.Value;

            try
            {
                var contentRootPath = env.ContentRootPath;
                var webroot = env.WebRootPath;

                if (!context.Users.Any())
                {
                    foreach(var user in GetDefaultUser())
                    {
                        await userManager.CreateAsync(user, "Password123@");
                    }
                }
            }
            catch (Exception ex)
            {
                if (retryForAvaiability < 10)
                {
                    retryForAvaiability++;

                    logger.LogError(ex, "EXCEPTION ERROR while migrating {DbContextName}", nameof(ApplicationDbContext));

                    await SeedAsync(context, env, logger, userManager, retryForAvaiability);
                }
            }
        }


        private IEnumerable<IdentityUser> GetDefaultUser()
        {
            var user =
            new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                PhoneNumber = "1234567890",
                UserName = "admin@admin.com",
                NormalizedEmail = "admin@admin.com".ToUpperInvariant(),
                NormalizedUserName = "admin@admin.com".ToUpperInvariant(),
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };
            return new List<IdentityUser>()
            {
                user
            };
        }
    }
}
