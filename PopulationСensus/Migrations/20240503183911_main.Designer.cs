﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PopulationСensus.Data;

#nullable disable

namespace PopulationСensus.Migrations
{
    [DbContext(typeof(СensusContext))]
    [Migration("20240503183911_main")]
    partial class main
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PopulationСensus.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<short>("ApartmentNumber")
                        .HasColumnType("smallint");

                    b.Property<string>("City")
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("State")
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("Street")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PopulationСensus.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PopulationСensus.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("FullName")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Password")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Salt")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("UserAnswersId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserAnswersId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PopulationСensus.Domain.Entities.UserAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("CanReadAndWrite")
                        .HasColumnType("boolean");

                    b.Property<string>("Citizenship")
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("Education")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<bool>("Gender")
                        .HasColumnType("boolean");

                    b.Property<bool>("HaveDegree")
                        .HasColumnType("boolean");

                    b.Property<bool>("LivedOtherCountries")
                        .HasColumnType("boolean");

                    b.Property<string>("MaritalStatus")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Nationality")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NativeLanguage")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<byte?>("CountPeopleLivingHousehold")
                        .HasColumnType("smallint");

                    b.Property<string>("PlaceBirth")
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<bool>("SpeakRussian")
                        .HasColumnType("boolean");

                    b.Property<bool>("UseRussianInConversation")
                        .HasColumnType("boolean");

                    b.Property<string>("WhereLiveBeforeArriving")
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<short?>("YearArrival")
                        .HasColumnType("smallint");

                    b.Property<short?>("CountPeopleLivingHousehold")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("UserAnswer");
                });

            modelBuilder.Entity("PopulationСensus.Domain.Entities.User", b =>
                {
                    b.HasOne("PopulationСensus.Domain.Entities.Address", "Address")
                        .WithMany("User")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PopulationСensus.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PopulationСensus.Domain.Entities.UserAnswer", "UserAnswer")
                        .WithOne("User")
                        .HasForeignKey("PopulationСensus.Domain.Entities.User", "UserAnswersId");

                    b.Navigation("Address");

                    b.Navigation("Role");

                    b.Navigation("UserAnswer");
                });

            modelBuilder.Entity("PopulationСensus.Domain.Entities.Address", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("PopulationСensus.Domain.Entities.UserAnswer", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
