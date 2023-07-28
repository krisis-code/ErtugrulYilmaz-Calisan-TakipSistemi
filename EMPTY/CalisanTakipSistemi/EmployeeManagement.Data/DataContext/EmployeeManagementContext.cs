using CalisanTakipSistemi.Data.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalisanTakipSistemi.Data.DataContext
{
    public class EmployeeManagementContext :IdentityDbContext
    {
        public EmployeeManagementContext(DbContextOptions options) 
            : base(options) 
        {

        }
        public DbSet<Employe> employe { get; set; }
    }
}
