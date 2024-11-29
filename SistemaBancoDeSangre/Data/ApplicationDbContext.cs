using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaBancoDeSangre.Models;

namespace SistemaBancoDeSangre.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SistemaBancoDeSangre.Models.Donante> Donante { get; set; }
        public DbSet<SistemaBancoDeSangre.Models.CentroDonacion> CentroDonacion { get; set; }
        public DbSet<SistemaBancoDeSangre.Models.ControlDonaciones> ControlDonaciones { get; set; }
    }
}
