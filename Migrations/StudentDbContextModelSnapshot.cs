﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement.Data;

#nullable disable

namespace StudentManagement.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StudentManagement.Models.Domain.Grade", b =>
                {
                    b.Property<Guid>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("GradeName")
                        .HasColumnType("longtext");

                    b.Property<string>("Section")
                        .HasColumnType("longtext");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            GradeId = new Guid("51c5dd14-2798-4c9b-8722-31153b6770b7"),
                            GradeName = "5th Standard",
                            Section = "Asec"
                        },
                        new
                        {
                            GradeId = new Guid("778c4497-c1f5-462c-a4e9-d828edf142c9"),
                            GradeName = "6th Standard",
                            Section = "Bsec"
                        },
                        new
                        {
                            GradeId = new Guid("7a1a61fa-e271-4e72-baca-f8c5c9c1a53d"),
                            GradeName = "7th Standard",
                            Section = "Asec"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Domain.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("StudentManagement.Models.Domain.Student", b =>
                {
                    b.Property<Guid>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("GradeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StudentAddressId")
                        .HasColumnType("char(36)");

                    b.Property<string>("StudentName")
                        .HasColumnType("longtext");

                    b.HasKey("StudentID");

                    b.HasIndex("GradeId");

                    b.HasIndex("StudentAddressId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentID = new Guid("40de7589-9dcc-4e57-8465-414998a6dcf7"),
                            DateOfBirth = new DateTime(1999, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GradeId = new Guid("51c5dd14-2798-4c9b-8722-31153b6770b7"),
                            StudentAddressId = new Guid("be497bea-8a87-49a7-9f19-daf62376ffc6"),
                            StudentName = "Alex"
                        },
                        new
                        {
                            StudentID = new Guid("973362c8-c169-4387-8c7f-0a25b22326a6"),
                            DateOfBirth = new DateTime(1999, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GradeId = new Guid("778c4497-c1f5-462c-a4e9-d828edf142c9"),
                            StudentAddressId = new Guid("be497bea-8a87-49a7-9f19-daf62376ffc6"),
                            StudentName = "Bob"
                        },
                        new
                        {
                            StudentID = new Guid("ca70207f-d972-4ab1-9cbe-d88d880269b8"),
                            DateOfBirth = new DateTime(1999, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GradeId = new Guid("7a1a61fa-e271-4e72-baca-f8c5c9c1a53d"),
                            StudentAddressId = new Guid("f7c18c0f-aa1b-40be-b653-7bbbfd4e4a4b"),
                            StudentName = "Otto"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Domain.StudentAddress", b =>
                {
                    b.Property<Guid>("StudentAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.HasKey("StudentAddressId");

                    b.ToTable("StudentAddresses");

                    b.HasData(
                        new
                        {
                            StudentAddressId = new Guid("644a0074-a67a-4744-884e-e6191f13f1f1"),
                            Address = "2nd Mian 3rd Cross",
                            City = "Jagalur",
                            Country = "India",
                            State = "Karnataka"
                        },
                        new
                        {
                            StudentAddressId = new Guid("be497bea-8a87-49a7-9f19-daf62376ffc6"),
                            Address = "3rd Mian 2nd Cross",
                            City = "Durga",
                            Country = "India",
                            State = "Karnataka"
                        },
                        new
                        {
                            StudentAddressId = new Guid("f7c18c0f-aa1b-40be-b653-7bbbfd4e4a4b"),
                            Address = " 2nd Cross",
                            City = "Davangere",
                            Country = "India",
                            State = "Karnataka"
                        });
                });

            modelBuilder.Entity("StudentManagement.Models.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentManagement.Models.Domain.User_Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Users_Roles");
                });

            modelBuilder.Entity("StudentManagement.Models.Domain.Student", b =>
                {
                    b.HasOne("StudentManagement.Models.Domain.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement.Models.Domain.StudentAddress", "Address")
                        .WithMany("Students")
                        .HasForeignKey("StudentAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("StudentManagement.Models.Domain.User_Role", b =>
                {
                    b.HasOne("StudentManagement.Models.Domain.Role", "role")
                        .WithMany("roleUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement.Models.Domain.User", "user")
                        .WithMany("userRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");

                    b.Navigation("user");
                });

            modelBuilder.Entity("StudentManagement.Models.Domain.Grade", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentManagement.Models.Domain.Role", b =>
                {
                    b.Navigation("roleUsers");
                });

            modelBuilder.Entity("StudentManagement.Models.Domain.StudentAddress", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentManagement.Models.Domain.User", b =>
                {
                    b.Navigation("userRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
