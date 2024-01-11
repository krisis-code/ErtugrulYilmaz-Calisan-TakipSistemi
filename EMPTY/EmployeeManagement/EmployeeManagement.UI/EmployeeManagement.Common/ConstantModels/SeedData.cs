using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common.ConstantModels
{
    public static class SeedData
    {
        public static void Seed(UserManager<Employee> userManager,RoleManager<IdentityRole> roleManager)
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

            if (userManager.FindByNameAsync(ResultConstant.Admin_Email).Result == null)
            {
                var user = new Employee
                {
                    UserName = ResultConstant.Admin_Email,
                    Email = ResultConstant.Admin_Email,
                    // Diğer özellikleri de ayarlayın
                };

                // Kullanıcıyı oluşturun
                IdentityResult result = userManager.CreateAsync(user, ResultConstant.Admin_Password).Result;

                if (result.Succeeded)
                {
                    // Rol ataması yapın (örneğin Admin rolü)
                    userManager.AddToRoleAsync(user, ResultConstant.Admin_Role).Wait();
                }
                else
                {
                    // Kullanıcı oluşturma başarısız oldu, hata işleme
                    throw new Exception($"SeedUsers: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
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
    }
}
