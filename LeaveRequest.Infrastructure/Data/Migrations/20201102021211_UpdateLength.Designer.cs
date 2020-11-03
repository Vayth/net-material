﻿// <auto-generated />
using System;
using LeaveRequest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeaveRequest.Infrastructure.Data.Migrations
{
    [DbContext(typeof(LeaveRequestDbContext))]
    [Migration("20201102021211_UpdateLength")]
    partial class UpdateLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LeaveRequest.Domain.Employees.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("LeaveRequest.Domain.Employees.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ReportToPositionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReportToPositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("LeaveRequest.Domain.Employees.Employee", b =>
                {
                    b.HasOne("LeaveRequest.Domain.Employees.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.OwnsOne("LeaveRequest.Domain.Employees.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("EmployeeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.OwnsOne("LeaveRequest.Domain.Employees.ValueObjects.EmployeeName", "Name", b1 =>
                        {
                            b1.Property<Guid>("EmployeeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(256)")
                                .HasMaxLength(256);

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(256)")
                                .HasMaxLength(256);

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });
                });

            modelBuilder.Entity("LeaveRequest.Domain.Employees.Position", b =>
                {
                    b.HasOne("LeaveRequest.Domain.Employees.Position", "ReportToPosition")
                        .WithMany()
                        .HasForeignKey("ReportToPositionId");
                });
#pragma warning restore 612, 618
        }
    }
}
