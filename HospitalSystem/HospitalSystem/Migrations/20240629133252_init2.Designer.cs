﻿// <auto-generated />
using System;
using HospitalSystem.Models.databaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalSystem.Migrations
{
    [DbContext(typeof(MasterDbContext))]
    [Migration("20240629133252_init2")]
    partial class init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.ClinicModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("speciality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("clinicDb");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.DrugsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("recipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("recipeId");

                    b.ToTable("DrugsListDb");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.appointmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("appointmentDb");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.doctorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("clinicID")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("speciality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("clinicID");

                    b.ToTable("doctorDb");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.patientModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("patientDb");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("recipesDb");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.reportsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("report")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("reportsDb");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.roomModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("statement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("roomDb");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.roomWaitingListModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("roomWaitingListDb");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.DrugsModel", b =>
                {
                    b.HasOne("HospitalSystem.Models.databaseModels.recipe", null)
                        .WithMany("drugs")
                        .HasForeignKey("recipeId");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.appointmentModel", b =>
                {
                    b.HasOne("HospitalSystem.Models.databaseModels.doctorModel", "doctorModel")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalSystem.Models.databaseModels.patientModel", "patientModel")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctorModel");

                    b.Navigation("patientModel");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.doctorModel", b =>
                {
                    b.HasOne("HospitalSystem.Models.databaseModels.ClinicModel", "clinicModel")
                        .WithMany()
                        .HasForeignKey("clinicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clinicModel");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.recipe", b =>
                {
                    b.HasOne("HospitalSystem.Models.databaseModels.doctorModel", "doctorModel")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalSystem.Models.databaseModels.patientModel", "patientModel")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctorModel");

                    b.Navigation("patientModel");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.reportsModel", b =>
                {
                    b.HasOne("HospitalSystem.Models.databaseModels.doctorModel", "doctorModel")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalSystem.Models.databaseModels.patientModel", "patientModel")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctorModel");

                    b.Navigation("patientModel");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.roomModel", b =>
                {
                    b.HasOne("HospitalSystem.Models.databaseModels.patientModel", "patientModel")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("patientModel");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.roomWaitingListModel", b =>
                {
                    b.HasOne("HospitalSystem.Models.databaseModels.patientModel", "patientModel")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patientModel");
                });

            modelBuilder.Entity("HospitalSystem.Models.databaseModels.recipe", b =>
                {
                    b.Navigation("drugs");
                });
#pragma warning restore 612, 618
        }
    }
}
