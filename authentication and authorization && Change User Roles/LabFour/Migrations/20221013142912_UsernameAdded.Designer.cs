﻿// <auto-generated />
using LabFour.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabFour.Migrations
{
    [DbContext(typeof(ITIDB))]
    [Migration("20221013142912_UsernameAdded")]
    partial class UsernameAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.Property<int>("CoursesCrsId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentsDeptId")
                        .HasColumnType("int");

                    b.HasKey("CoursesCrsId", "DepartmentsDeptId");

                    b.HasIndex("DepartmentsDeptId");

                    b.ToTable("CourseDepartment");
                });

            modelBuilder.Entity("LabFour.Models.Course", b =>
                {
                    b.Property<int>("CrsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrsId"), 1L, 1);

                    b.Property<string>("CrsName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Crs_Hours")
                        .HasColumnType("int");

                    b.HasKey("CrsId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LabFour.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("DeptId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("LabFour.Models.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("DeptNo")
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("DeptNo");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LabFour.Models.StudentCourses", b =>
                {
                    b.Property<int>("stdId")
                        .HasColumnType("int");

                    b.Property<int>("CrsId")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.HasKey("stdId", "CrsId");

                    b.HasIndex("CrsId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.HasOne("LabFour.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabFour.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsDeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LabFour.Models.Student", b =>
                {
                    b.HasOne("LabFour.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DeptNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("LabFour.Models.StudentCourses", b =>
                {
                    b.HasOne("LabFour.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabFour.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("stdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LabFour.Models.Course", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("LabFour.Models.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("LabFour.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
