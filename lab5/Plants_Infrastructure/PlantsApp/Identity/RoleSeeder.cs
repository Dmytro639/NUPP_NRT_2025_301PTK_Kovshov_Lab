using Microsoft.AspNetCore.Identity;
using PlantsApp.Entities;

namespace PlantsApp.Identity
{
    public class RoleSeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleSeeder(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedRolesAsync()
        {
            var roles = new[] { "User", "Gardener", "Admin" };
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                    await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        public async Task SeedAdminUserAsync()
        {
            var adminEmail = "admin@plants.local";
            var adminPassword = "Admin123!";

            var existing = await _userManager.FindByEmailAsync(adminEmail);
            if (existing == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FullName = "Administrator"
                };

                var result = await _userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                    await _userManager.AddToRolesAsync(admin, new[] { "Admin", "Gardener" });
            }
        }
    }
}
