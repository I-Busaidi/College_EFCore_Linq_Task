﻿// <auto-generated />
using System;
using College_EFCore_Linq_Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace College_EFCore_Linq_Task.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241110045802_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Duration")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CourseID");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptId"));

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Exam", b =>
                {
                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<int>("Exam_Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Exam_Code"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("Room")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.HasKey("Dept_Id", "Exam_Code");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Faculty", b =>
                {
                    b.Property<int>("FID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FID"));

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("FDepartment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("FID");

                    b.HasIndex("DeptId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.FacultyMobile", b =>
                {
                    b.Property<int>("FID")
                        .HasColumnType("int");

                    b.Property<string>("Mobile_no")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FID", "Mobile_no");

                    b.ToTable("FacultyMobiles");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Hostel", b =>
                {
                    b.Property<int>("Hostel_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Hostel_Id"));

                    b.Property<string>("Hostel_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("No_of_seats")
                        .HasColumnType("int");

                    b.HasKey("Hostel_Id");

                    b.ToTable("Hostels");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Student", b =>
                {
                    b.Property<int>("SID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<int>("FID")
                        .HasColumnType("int");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hostel_Id")
                        .HasColumnType("int");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pin_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SID");

                    b.HasIndex("FID");

                    b.HasIndex("Hostel_Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.StudentCourse", b =>
                {
                    b.Property<int>("SID")
                        .HasColumnType("int");

                    b.Property<int>("Course_id")
                        .HasColumnType("int");

                    b.HasKey("SID", "Course_id");

                    b.HasIndex("Course_id");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.StudentPhone", b =>
                {
                    b.Property<int>("SID")
                        .HasColumnType("int");

                    b.Property<string>("Phone_no")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SID", "Phone_no");

                    b.ToTable("StudentPhones");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Subject", b =>
                {
                    b.Property<int>("Subject_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Subject_Id"));

                    b.Property<string>("Subject_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Teacher_Id")
                        .HasColumnType("int");

                    b.HasKey("Subject_Id");

                    b.HasIndex("Teacher_Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Course", b =>
                {
                    b.HasOne("College_EFCore_Linq_Task.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Exam", b =>
                {
                    b.HasOne("College_EFCore_Linq_Task.Models.Department", "Department")
                        .WithMany("Exams")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Faculty", b =>
                {
                    b.HasOne("College_EFCore_Linq_Task.Models.Department", "Department")
                        .WithMany("Faculties")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.FacultyMobile", b =>
                {
                    b.HasOne("College_EFCore_Linq_Task.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Student", b =>
                {
                    b.HasOne("College_EFCore_Linq_Task.Models.Faculty", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("FID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("College_EFCore_Linq_Task.Models.Hostel", "Hostel")
                        .WithMany("Students")
                        .HasForeignKey("Hostel_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hostel");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.StudentCourse", b =>
                {
                    b.HasOne("College_EFCore_Linq_Task.Models.Course", "Course")
                        .WithMany("StudentsInCourse")
                        .HasForeignKey("Course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("College_EFCore_Linq_Task.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("SID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.StudentPhone", b =>
                {
                    b.HasOne("College_EFCore_Linq_Task.Models.Student", "Student")
                        .WithMany("StudentPhones")
                        .HasForeignKey("SID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Subject", b =>
                {
                    b.HasOne("College_EFCore_Linq_Task.Models.Faculty", "Teacher")
                        .WithMany("Subjects")
                        .HasForeignKey("Teacher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Course", b =>
                {
                    b.Navigation("StudentsInCourse");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Exams");

                    b.Navigation("Faculties");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Faculty", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Hostel", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("College_EFCore_Linq_Task.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");

                    b.Navigation("StudentPhones");
                });
#pragma warning restore 612, 618
        }
    }
}
