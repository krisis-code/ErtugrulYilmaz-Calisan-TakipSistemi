using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EmployeeManagement.Common.ConstantModels
{
    public static class SeedData
    {
        public static void Seed(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<Employee> userManager)
        {
            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager));
            }

            var existingUser = userManager.FindByNameAsync(ResultConstant.Admin_Email).Result;

            if (existingUser == null)
            {
                var user = new Employee
                {
                    FirstName = ResultConstant.Admin_FirstName,
                    LastName = ResultConstant.Admin_LastName,
                    UserName = ResultConstant.Admin_Email,
                    Email = ResultConstant.Admin_Email,
                    TaxId = "1"
                    // Diğer özellikleri de ayarlayın
                };

                try
                {
                    // Kullanıcıyı oluşturun
                    IdentityResult result = userManager.CreateAsync(user, ResultConstant.Admin_Password.ToString()).Result;

                    if (result.Succeeded)
                    {
                        // Rol ataması yapın (örneğin Admin rolü)
                        userManager.AddToRoleAsync(user, ResultConstant.Admin_Role).Wait();
                    }
                    else
                    {
                        throw new Exception($"SeedUsers: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception($"DbUpdateException: {ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}", ex);
                }
            }
            else
            {
                Console.WriteLine("User already exists.");
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager == null)
            {
                throw new ArgumentNullException(nameof(roleManager));
            }

            try
            {
                if (!roleManager.RoleExistsAsync(ResultConstant.Admin_Role).Result)
                {
                    var role = new IdentityRole
                    {
                        Name = ResultConstant.Admin_Role
                    };
                    var result = roleManager.CreateAsync(role).Result;
                }
                if (!roleManager.RoleExistsAsync(ResultConstant.Employee_Role).Result)
                {
                    var role = new IdentityRole
                    {
                        Name = ResultConstant.Employee_Role
                    };
                    var result = roleManager.CreateAsync(role).Result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating roles: {ex.Message}", ex);
            }
        }
    }
}
