﻿// <auto-generated />
using System;
using ContactRecord.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactRecord.Infrastructure.Migrations
{
    [DbContext(typeof(ContactRecordContext))]
    [Migration("20200921114153_CreateContactRecordDB")]
    partial class CreateContactRecordDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:cr.contact_record_hilo", "'contact_record_hilo', 'cr', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactRecord.Core.Entities.ContactRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "contact_record_hilo")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "cr")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("ContactRecord","cr");
                });

            modelBuilder.Entity("ContactRecord.Core.Entities.ContactRecord", b =>
                {
                    b.OwnsOne("ContactRecord.Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ContactRecordId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Number")
                                .HasColumnType("int");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ContactRecordId");

                            b1.ToTable("ContactRecord");

                            b1.WithOwner()
                                .HasForeignKey("ContactRecordId");
                        });

                    b.OwnsOne("ContactRecord.Core.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("ContactRecordId")
                                .HasColumnType("int");

                            b1.Property<string>("PersonalNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("WorkNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ContactRecordId");

                            b1.ToTable("ContactRecord");

                            b1.WithOwner()
                                .HasForeignKey("ContactRecordId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}