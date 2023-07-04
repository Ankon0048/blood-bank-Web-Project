﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using blood_bank.data;

#nullable disable

namespace blood_bank.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230629124835_AddedUsernameBloodStory")]
    partial class AddedUsernameBloodStory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("blood_bank.Models.AdminHomeData", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AdminHomeDatas");
                });

            modelBuilder.Entity("blood_bank.Models.BloodStory", b =>
                {
                    b.Property<int?>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Count"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Story")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Count");

                    b.ToTable("BloodStories");
                });

            modelBuilder.Entity("blood_bank.Models.EventData", b =>
                {
                    b.Property<string>("DonorID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DonorID");

                    b.ToTable("EventDatas");
                });

            modelBuilder.Entity("blood_bank.Models.EventDesc", b =>
                {
                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BloodCollected")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventName");

                    b.ToTable("EventDescs");
                });

            modelBuilder.Entity("blood_bank.Models.HospitalData", b =>
                {
                    b.Property<string>("HospitalName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ABnegative")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ABpositive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Anegative")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apositive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bnegative")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bpositive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Onegative")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opositive")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HospitalName");

                    b.ToTable("HospitalDatas");
                });

            modelBuilder.Entity("blood_bank.Models.HospitalDesc", b =>
                {
                    b.Property<string>("HospitalName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HospitalName");

                    b.ToTable("HospitalDescs");
                });

            modelBuilder.Entity("blood_bank.Models.ReportData", b =>
                {
                    b.Property<int?>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Count"));

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bloodgroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Count");

                    b.ToTable("ReportDatas");
                });

            modelBuilder.Entity("blood_bank.Models.UserNotification", b =>
                {
                    b.Property<int?>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Count"));

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Count");

                    b.ToTable("UserNotifications");
                });

            modelBuilder.Entity("blood_bank.Models.Userprofile", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bloodgrp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Userprofiles");
                });

            modelBuilder.Entity("blood_bank.Models.VolunteerData", b =>
                {
                    b.Property<string>("VolunteerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bloodgroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VolunteerID");

                    b.ToTable("VolunteerDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
