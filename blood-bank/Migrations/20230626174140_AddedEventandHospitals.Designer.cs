﻿// <auto-generated />
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
    [Migration("20230626174140_AddedEventandHospitals")]
    partial class AddedEventandHospitals
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

                    b.Property<string>("BloodGroup")
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

                    b.Property<string>("Onegative")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opositive")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HospitalName");

                    b.ToTable("HospitalDatas");
                });

            modelBuilder.Entity("blood_bank.Models.UserNotification", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserNotifications");
                });

            modelBuilder.Entity("blood_bank.Models.Userprofile", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Bloodgrp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Userprofiles");
                });
#pragma warning restore 612, 618
        }
    }
}
