﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecureMindAPI.Data;

#nullable disable

namespace SecureMindAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240906043836_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SecureMindAPI.Models.Counsellors", b =>
                {
                    b.Property<int>("CounsellorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CounsellorId"));

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CounsellorId");

                    b.HasIndex("LocationId");

                    b.ToTable("MentalHealthProfessionals");
                });

            modelBuilder.Entity("SecureMindAPI.Models.Incidents", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncidentId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReportTime")
                        .HasColumnType("datetime2");

                    b.HasKey("IncidentId");

                    b.HasIndex("LocationId");

                    b.ToTable("CrimeIncidents");
                });

            modelBuilder.Entity("SecureMindAPI.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("SecureMindAPI.Models.Reports", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReportTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReportId");

                    b.HasIndex("LocationId");

                    b.ToTable("AnonymousReports");
                });

            modelBuilder.Entity("SecureMindAPI.Models.Counsellors", b =>
                {
                    b.HasOne("SecureMindAPI.Models.Location", "Location")
                        .WithMany("MentalHealthProfessionals")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("SecureMindAPI.Models.Incidents", b =>
                {
                    b.HasOne("SecureMindAPI.Models.Location", "Location")
                        .WithMany("CrimeIncidents")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("SecureMindAPI.Models.Reports", b =>
                {
                    b.HasOne("SecureMindAPI.Models.Location", "Location")
                        .WithMany("AnonymousReports")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("SecureMindAPI.Models.Location", b =>
                {
                    b.Navigation("AnonymousReports");

                    b.Navigation("CrimeIncidents");

                    b.Navigation("MentalHealthProfessionals");
                });
#pragma warning restore 612, 618
        }
    }
}
