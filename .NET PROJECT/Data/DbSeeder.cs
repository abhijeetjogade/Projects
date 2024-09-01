using Microsoft.AspNetCore.Identity;
using MedLab.Models;
using MedLab.Constants;
using System.Threading.Tasks;

namespace MedLab.Data
{
    public static class DBSeeder
    {
        public static async Task SeedRolesAndAdminUser(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            // Define roles
            var roles = new[]
            {
                UserRole.PATIENT.ToString(),
                UserRole.LABASSISTANT.ToString()
            };

            // Seed roles (do not seed ADMIN role if predefined)
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole<int>(role));
                }
            }

            // Check if the ADMIN role exists (predefined)
            var adminRole = UserRole.ADMIN.ToString();
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                // Log a warning or handle the missing role case
                // You might want to throw an exception or notify the admin if the role is expected to exist
                throw new InvalidOperationException($"The required role '{adminRole}' does not exist in the system.");
            }

            // Seed the Admin user
            var adminEmail = "admin@medlab.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Role = UserRole.ADMIN,
                    Name = "Admin User"
                };

                var createUserResult = await userManager.CreateAsync(adminUser, "Admin@123");
                if (createUserResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }
                else
                {
                    // Handle errors here (log them, throw exception, etc.)
                    throw new InvalidOperationException("Failed to create admin user.");
                }
            }
        }
    }
}
