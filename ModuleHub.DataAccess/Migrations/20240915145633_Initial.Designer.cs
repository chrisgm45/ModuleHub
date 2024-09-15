﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModuleHub.DataAccess.Contexts;

#nullable disable

namespace ModuleHub.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240915145633_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.27");

            modelBuilder.Entity("ModuleHub.Domain.Entities.Common.CommunicationNode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ComunnicationClientId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CommunicationNodes");
                });

            modelBuilder.Entity("ModuleHub.Domain.Entities.CommunicationClient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressIp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConnectionPort")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DataSourceId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DataSourceId")
                        .IsUnique();

                    b.ToTable("CommunicationClients");
                });

            modelBuilder.Entity("ModuleHub.Domain.Entities.DataSource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DataSourceType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("InputsCounter")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OutputsCounter")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DataSources");
                });

            modelBuilder.Entity("ModuleHub.Domain.Entities.ModbusNode", b =>
                {
                    b.HasBaseType("ModuleHub.Domain.Entities.Common.CommunicationNode");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RecordSource")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecordToRead")
                        .HasColumnType("INTEGER");

                    b.ToTable("ModbusNodes", (string)null);
                });

            modelBuilder.Entity("ModuleHub.Domain.Entities.OPCNode", b =>
                {
                    b.HasBaseType("ModuleHub.Domain.Entities.Common.CommunicationNode");

                    b.Property<string>("AddressLabel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("OPCNodes", (string)null);
                });

            modelBuilder.Entity("ModuleHub.Domain.Entities.CommunicationClient", b =>
                {
                    b.HasOne("ModuleHub.Domain.Entities.DataSource", "DataSource")
                        .WithOne("CommunicationClient")
                        .HasForeignKey("ModuleHub.Domain.Entities.CommunicationClient", "DataSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataSource");
                });

            modelBuilder.Entity("ModuleHub.Domain.Entities.ModbusNode", b =>
                {
                    b.HasOne("ModuleHub.Domain.Entities.Common.CommunicationNode", null)
                        .WithOne()
                        .HasForeignKey("ModuleHub.Domain.Entities.ModbusNode", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ModuleHub.Domain.Entities.OPCNode", b =>
                {
                    b.HasOne("ModuleHub.Domain.Entities.Common.CommunicationNode", null)
                        .WithOne()
                        .HasForeignKey("ModuleHub.Domain.Entities.OPCNode", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ModuleHub.Domain.Entities.DataSource", b =>
                {
                    b.Navigation("CommunicationClient")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
