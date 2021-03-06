﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpliPromo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpliPromo.ViewModels
{
    public class ProfileContext:IdentityDbContext<ApplicationUser>
    {
        public ProfileContext(DbContextOptions<ProfileContext> options):base(options)
        {   

        }
        DbSet<Login> ApplicationLogin { get; set; }
        DbSet<Register> Registration { get; set; }
    }
}
