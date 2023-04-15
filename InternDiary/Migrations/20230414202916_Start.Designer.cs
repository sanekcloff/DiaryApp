﻿// <auto-generated />
using System;
using InternDiary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InternDiary.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230414202916_Start")]
    partial class Start
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InternDiary.Entities.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsAttend")
                        .HasColumnType("bit");

                    b.Property<int?>("Result")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("InternDiary.Entities.Diary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Diaries");
                });

            modelBuilder.Entity("InternDiary.Entities.DiaryDay", b =>
                {
                    b.Property<int>("DiaryId")
                        .HasColumnType("int");

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.HasKey("DiaryId", "DayId");

                    b.HasIndex("DayId");

                    b.ToTable("DiaryDays");
                });

            modelBuilder.Entity("InternDiary.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("InternDiary.Entities.Practice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Practices");
                });

            modelBuilder.Entity("InternDiary.Entities.PracticeDiary", b =>
                {
                    b.Property<int>("PracticeId")
                        .HasColumnType("int");

                    b.Property<int>("DiaryId")
                        .HasColumnType("int");

                    b.HasKey("PracticeId", "DiaryId");

                    b.HasIndex("DiaryId");

                    b.ToTable("PracticeDiaries");
                });

            modelBuilder.Entity("InternDiary.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("InternDiary.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InternDiary.Entities.Diary", b =>
                {
                    b.HasOne("InternDiary.Entities.User", "User")
                        .WithMany("Diaries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InternDiary.Entities.DiaryDay", b =>
                {
                    b.HasOne("InternDiary.Entities.Day", "Day")
                        .WithMany("DiaryDays")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternDiary.Entities.Diary", "Diary")
                        .WithMany()
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("Diary");
                });

            modelBuilder.Entity("InternDiary.Entities.Practice", b =>
                {
                    b.HasOne("InternDiary.Entities.Organization", "Organization")
                        .WithMany("Practices")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("InternDiary.Entities.PracticeDiary", b =>
                {
                    b.HasOne("InternDiary.Entities.Diary", "Diary")
                        .WithMany("PracticeDiaries")
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternDiary.Entities.Practice", "Practice")
                        .WithMany("PracticeDiaries")
                        .HasForeignKey("PracticeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diary");

                    b.Navigation("Practice");
                });

            modelBuilder.Entity("InternDiary.Entities.User", b =>
                {
                    b.HasOne("InternDiary.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("InternDiary.Entities.Day", b =>
                {
                    b.Navigation("DiaryDays");
                });

            modelBuilder.Entity("InternDiary.Entities.Diary", b =>
                {
                    b.Navigation("PracticeDiaries");
                });

            modelBuilder.Entity("InternDiary.Entities.Organization", b =>
                {
                    b.Navigation("Practices");
                });

            modelBuilder.Entity("InternDiary.Entities.Practice", b =>
                {
                    b.Navigation("PracticeDiaries");
                });

            modelBuilder.Entity("InternDiary.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("InternDiary.Entities.User", b =>
                {
                    b.Navigation("Diaries");
                });
#pragma warning restore 612, 618
        }
    }
}
