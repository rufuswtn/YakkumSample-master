using System;
using System.Collections.Generic;
using System.Text;
using DokumenWebApps.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DokumenWebApps.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Klasifikasi> Klasifikasi { get; set; }
        public DbSet<Dokumen> Dokumen { get; set; }
    }
}
