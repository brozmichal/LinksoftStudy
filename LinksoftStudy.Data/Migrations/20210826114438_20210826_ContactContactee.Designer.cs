﻿// <auto-generated />
using System;
using LinksoftStudy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LinksoftStudy.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210826114438_20210826_ContactContactee")]
    partial class _20210826_ContactContactee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LinksoftStudy.Data.Models.ContactContacteeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<int>("ContacteeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PersonEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("ContacteeId");

                    b.HasIndex("PersonEntityId");

                    b.ToTable("ContactContactee");
                });

            modelBuilder.Entity("LinksoftStudy.Data.Models.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("LinksoftStudy.Data.Models.ContactContacteeEntity", b =>
                {
                    b.HasOne("LinksoftStudy.Data.Models.PersonEntity", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LinksoftStudy.Data.Models.PersonEntity", "Contactee")
                        .WithMany("Contact")
                        .HasForeignKey("ContacteeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LinksoftStudy.Data.Models.PersonEntity", null)
                        .WithMany("Contactee")
                        .HasForeignKey("PersonEntityId");

                    b.Navigation("Contact");

                    b.Navigation("Contactee");
                });

            modelBuilder.Entity("LinksoftStudy.Data.Models.PersonEntity", b =>
                {
                    b.Navigation("Contact");

                    b.Navigation("Contactee");
                });
#pragma warning restore 612, 618
        }
    }
}