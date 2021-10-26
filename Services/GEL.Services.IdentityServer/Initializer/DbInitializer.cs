using GEL.Services.IdentityServer.DbContexts;
using GEL.Services.IdentityServer.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GEL.Services.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DbInitializer(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void Initialize()
        {
            if (roleManager.FindByNameAsync(StaticDetails.Admin) == null)
            {
                roleManager.CreateAsync(new IdentityRole(StaticDetails.Admin)).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(StaticDetails.Viewer)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            ApplicationUser adminUser = new()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "0123456789",
                FirstName = "Huy",
                LastName = "Nguyen"
            };

            userManager.CreateAsync(adminUser, "Admin@123").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(adminUser, StaticDetails.Admin).GetAwaiter().GetResult();

            var temp1 = userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{adminUser.FirstName} {adminUser.LastName}"),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, StaticDetails.Admin),
            }).Result;

            ApplicationUser viewerUser = new()
            {
                UserName = "viewer@gmail.com",
                Email = "viewer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "0123456789",
                FirstName = "Bao",
                LastName = "Nguyen"
            };

            userManager.CreateAsync(viewerUser, "Viewer#456").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(viewerUser, StaticDetails.Viewer).GetAwaiter().GetResult();

            var temp2 = userManager.AddClaimsAsync(viewerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{viewerUser.FirstName} {viewerUser.LastName}"),
                new Claim(JwtClaimTypes.GivenName, viewerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, viewerUser.LastName),
                new Claim(JwtClaimTypes.Role, StaticDetails.Viewer),
            }).Result;
        }
    }
}
