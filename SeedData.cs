using Microsoft.AspNetCore.Identity;
using MyMvcExamProject.Models;

public static class SeedData
{
    public static async Task CreateRoles(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        string[] roleNames = { "Admin", "User" }; // Admin ve User rolleri örnek olarak
        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Admin kullanıcısı ekleme işlemi
        string adminRole = "Admin";
        string adminEmail = "admin@example.com";
        string adminPassword = "Admin123!"; // Şifre kurallarına uymalı

        // Admin rolü varsa, admin kullanıcısını ekle
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            var user = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(user, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, adminRole);
            }
        }
    }
}
