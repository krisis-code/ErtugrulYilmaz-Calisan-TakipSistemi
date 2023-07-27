﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalisanTakipSistemi.Data.DbModels
{
    public class Employe : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
