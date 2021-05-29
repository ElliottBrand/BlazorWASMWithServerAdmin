using BlazorWASMWithServerAdmin.Server.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace BlazorWASMWithServerAdmin.Server.Data
{
    public class SeedUsers
    {
        public static void Initialize(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            SeedRole(roleManager);
            SeedUser(userManager);
        }

        private static void SeedRole(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.FindByNameAsync("admin").Result == null)
            {
                IdentityRole role = new IdentityRole() { Name = "admin" };
                roleManager.CreateAsync(role).Wait();
            }
            if (roleManager.FindByNameAsync("user").Result == null)
            {
                IdentityRole role = new IdentityRole() { Name = "user" };
                roleManager.CreateAsync(role).Wait();
            }
        }

        private static void SeedUser(UserManager<ApplicationUser> userManager)
        {
            string adminName = "admin@blazor.net";
            string pwd = "Password123!";
            string roleName = "admin";
            if (userManager.FindByNameAsync(adminName).Result == null)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = adminName,
                    Email = adminName,
                    EmailConfirmed = true
                };
                userManager.CreateAsync(user, pwd).Wait();

                if (userManager.FindByNameAsync(adminName).Result != null)
                {
                    userManager.AddToRoleAsync(user, roleName).Wait();
                }
            }
        }
    }
}
