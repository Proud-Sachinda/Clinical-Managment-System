﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Clinic_System.Models;

namespace Clinic_System.Data
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
        }

        public DbSet<Practitioner> Practitioners { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Procedure> Procedures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Practitioner>().ToTable("Practitioner");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Procedure>().ToTable("Procedure");
        }
    }
}
