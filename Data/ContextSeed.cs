using INTEX2.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Researcher.ToString()));
        }

        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default Admin
            //Set R Paul Evans as Admin
            var defaultUser1 = new ApplicationUser
            {
                UserName = "evansp",
                Email = "evansp@byu.edu",
                FirstName = "R Paul",
                LastName = "Evans",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            //Set Kerry Muhlestein as Admin
            var defaultUser2 = new ApplicationUser
            {
                UserName = "Kerry_Muhlestein",
                Email = "Kerry_Muhlestein@byu.edu",
                FirstName = "Kerry",
                LastName = "Muhlestein",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            //adds R Paul Evans to AspNetUsers and assigns him as admin
            if (userManager.Users.All(u => u.Id != defaultUser1.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser1.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser1, "M0lecularBiology!");
                    await userManager.AddToRoleAsync(defaultUser1, Enums.Roles.Admin.ToString());
                    
                }

            }

            //adds Kerry Muhlestein to AspNetUsers and assigns him as admin
            if (userManager.Users.All(u => u.Id != defaultUser2.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser2.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser2, "Pearl0fGreatPrice!");
                    await userManager.AddToRoleAsync(defaultUser2, Enums.Roles.Admin.ToString());

                }

            }
        }
    }
}
