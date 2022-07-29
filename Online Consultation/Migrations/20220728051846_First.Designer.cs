﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Online_Consultation.Models;

#nullable disable

namespace Online_Consultation.Migrations
{
    [DbContext(typeof(DoctorDbContext))]
    [Migration("20220728051846_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Online_Consultation.Models.Appointment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("did")
                        .HasColumnType("int");

                    b.Property<int>("pid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("did");

                    b.HasIndex("pid");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("Online_Consultation.Models.Billing", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("billingdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("did")
                        .HasColumnType("int");

                    b.Property<int>("mid")
                        .HasColumnType("int");

                    b.Property<int>("pid")
                        .HasColumnType("int");

                    b.Property<int>("totalFee")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("did");

                    b.HasIndex("mid");

                    b.HasIndex("pid");

                    b.ToTable("billings");
                });

            modelBuilder.Entity("Online_Consultation.Models.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("dname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("Online_Consultation.Models.DoctorProfile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Docname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("avail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("docImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("fees")
                        .HasColumnType("int");

                    b.Property<string>("speciality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("doctorsProfiles");
                });

            modelBuilder.Entity("Online_Consultation.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("DepId")
                        .HasColumnType("int");

                    b.Property<string>("Empname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("DepId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Online_Consultation.Models.Feedback", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("feedbackTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("pid")
                        .HasColumnType("int");

                    b.Property<byte>("rating")
                        .HasColumnType("tinyint");

                    b.HasKey("id");

                    b.HasIndex("pid");

                    b.ToTable("feedbacks");
                });

            modelBuilder.Entity("Online_Consultation.Models.Medicine", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("exp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("mfg")
                        .HasColumnType("datetime2");

                    b.Property<string>("mname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("mprice")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("medicines");
                });

            modelBuilder.Entity("Online_Consultation.Models.PatientProfile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("patientProfiles");
                });

            modelBuilder.Entity("Online_Consultation.Models.Service", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serviceDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("services");
                });

            modelBuilder.Entity("Online_Consultation.Models.Appointment", b =>
                {
                    b.HasOne("Online_Consultation.Models.DoctorProfile", "doctor")
                        .WithMany()
                        .HasForeignKey("did")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Consultation.Models.PatientProfile", "patient")
                        .WithMany()
                        .HasForeignKey("pid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctor");

                    b.Navigation("patient");
                });

            modelBuilder.Entity("Online_Consultation.Models.Billing", b =>
                {
                    b.HasOne("Online_Consultation.Models.DoctorProfile", "doctor")
                        .WithMany()
                        .HasForeignKey("did")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Consultation.Models.Medicine", "medicine")
                        .WithMany()
                        .HasForeignKey("mid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Consultation.Models.PatientProfile", "patient")
                        .WithMany()
                        .HasForeignKey("pid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctor");

                    b.Navigation("medicine");

                    b.Navigation("patient");
                });

            modelBuilder.Entity("Online_Consultation.Models.Employee", b =>
                {
                    b.HasOne("Online_Consultation.Models.Department", "department")
                        .WithMany()
                        .HasForeignKey("DepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("Online_Consultation.Models.Feedback", b =>
                {
                    b.HasOne("Online_Consultation.Models.PatientProfile", "patient")
                        .WithMany()
                        .HasForeignKey("pid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patient");
                });
#pragma warning restore 612, 618
        }
    }
}
