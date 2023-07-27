﻿using CalisanTakipSistemi.Data.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalisanTakipSistemi.Data.DataContext
{
    public class CalisanTakipSistemiContext :IdentityDbContext
    {
        public CalisanTakipSistemiContext(DbContextOptions options) 
            : base(options) 
        {

        }
        public DbSet<Employe> employe { get; set; }
    }
}
