﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pets.DataAccess;

namespace Pets.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:CollationDefinition:my_collation", "en-u-ks-primary,en-u-ks-primary,icu,False")
                .HasAnnotation("Npgsql:DefaultColumnCollation", "my_collation")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Pets.Core.Domain.Entities.AnimalEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BreedId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Pets.Core.Domain.Entities.Breed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AnimalBreeds");
                });

            modelBuilder.Entity("Pets.Core.Domain.Entities.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Pets.Core.Domain.ValueObjects.Feeding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AnimalId")
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("FoodId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("FoodId");

                    b.ToTable("Feedings");
                });

            modelBuilder.Entity("Pets.Core.Domain.Entities.Cat", b =>
                {
                    b.HasBaseType("Pets.Core.Domain.Entities.AnimalEntity");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric");

                    b.ToTable("Cat");
                });

            modelBuilder.Entity("Pets.Core.Domain.Entities.Dog", b =>
                {
                    b.HasBaseType("Pets.Core.Domain.Entities.AnimalEntity");

                    b.Property<decimal>("TailLength")
                        .HasColumnType("numeric");

                    b.ToTable("Dog");
                });

            modelBuilder.Entity("Pets.Core.Domain.Entities.AnimalEntity", b =>
                {
                    b.HasOne("Pets.Core.Domain.Entities.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId");

                    b.Navigation("Breed");
                });

            modelBuilder.Entity("Pets.Core.Domain.ValueObjects.Feeding", b =>
                {
                    b.HasOne("Pets.Core.Domain.Entities.AnimalEntity", "Animal")
                        .WithMany("Feedings")
                        .HasForeignKey("AnimalId");

                    b.HasOne("Pets.Core.Domain.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId");

                    b.Navigation("Animal");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("Pets.Core.Domain.Entities.Cat", b =>
                {
                    b.HasOne("Pets.Core.Domain.Entities.AnimalEntity", null)
                        .WithOne()
                        .HasForeignKey("Pets.Core.Domain.Entities.Cat", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pets.Core.Domain.Entities.Dog", b =>
                {
                    b.HasOne("Pets.Core.Domain.Entities.AnimalEntity", null)
                        .WithOne()
                        .HasForeignKey("Pets.Core.Domain.Entities.Dog", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pets.Core.Domain.Entities.AnimalEntity", b =>
                {
                    b.Navigation("Feedings");
                });
#pragma warning restore 612, 618
        }
    }
}
