﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NackademinUppgift07.DataModels;

#nullable disable

namespace NackademinUppgift07.Migrations
{
    [DbContext(typeof(TomasosContext))]
    [Migration("20241231052511_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.Bestallning", b =>
                {
                    b.Property<int>("BestallningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("BestallningID");

                    b.Property<DateTime>("BestallningDatum")
                        .HasColumnType("TEXT");

                    b.Property<int>("GratisPizzaPris")
                        .HasColumnType("INTEGER");

                    b.Property<string>("KundId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("KundID");

                    b.Property<bool>("Levererad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrdinalBelopp")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Rabatt")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<decimal>("Totalbelopp")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("BestallningId");

                    b.HasIndex("KundId");

                    b.ToTable("Bestallning");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.BestallningMatratt", b =>
                {
                    b.Property<int>("MatrattId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("MatrattID");

                    b.Property<int>("BestallningId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("BestallningID");

                    b.Property<int>("Antal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1);

                    b.HasKey("MatrattId", "BestallningId");

                    b.HasIndex("BestallningId");

                    b.ToTable("BestallningMatratt");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.Matratt", b =>
                {
                    b.Property<int>("MatrattId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("MatrattID");

                    b.Property<string>("Beskrivning")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("MatrattNamn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("MatrattTyp")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pris")
                        .HasColumnType("INTEGER");

                    b.HasKey("MatrattId");

                    b.HasIndex("MatrattTyp");

                    b.ToTable("Matratt");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.MatrattProdukt", b =>
                {
                    b.Property<int>("MatrattId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("MatrattID");

                    b.Property<int>("ProduktId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ProduktID");

                    b.HasKey("MatrattId", "ProduktId");

                    b.HasIndex("ProduktId");

                    b.ToTable("MatrattProdukt");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.MatrattTyp", b =>
                {
                    b.Property<int>("MatrattTyp1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("MatrattTyp");

                    b.Property<string>("Beskrivning")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("MatrattTyp1");

                    b.ToTable("MatrattTyp");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.Produkt", b =>
                {
                    b.Property<int>("ProduktId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ProduktID");

                    b.Property<string>("ProduktNamn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ProduktId");

                    b.ToTable("Produkt");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NackademinUppgift07.DataModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NackademinUppgift07.DataModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NackademinUppgift07.DataModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NackademinUppgift07.DataModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.Bestallning", b =>
                {
                    b.HasOne("NackademinUppgift07.DataModels.ApplicationUser", "Kund")
                        .WithMany("Bestallning")
                        .HasForeignKey("KundId")
                        .IsRequired()
                        .HasConstraintName("FK_Bestallning_Kund");

                    b.Navigation("Kund");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.BestallningMatratt", b =>
                {
                    b.HasOne("NackademinUppgift07.DataModels.Bestallning", "Bestallning")
                        .WithMany("BestallningMatratt")
                        .HasForeignKey("BestallningId")
                        .IsRequired()
                        .HasConstraintName("FK_BestallningMatratt_Bestallning");

                    b.HasOne("NackademinUppgift07.DataModels.Matratt", "Matratt")
                        .WithMany("BestallningMatratt")
                        .HasForeignKey("MatrattId")
                        .IsRequired()
                        .HasConstraintName("FK_BestallningMatratt_Matratt");

                    b.Navigation("Bestallning");

                    b.Navigation("Matratt");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.Matratt", b =>
                {
                    b.HasOne("NackademinUppgift07.DataModels.MatrattTyp", "MatrattTypNavigation")
                        .WithMany("Matratt")
                        .HasForeignKey("MatrattTyp")
                        .IsRequired()
                        .HasConstraintName("FK_Matratt_MatrattTyp");

                    b.Navigation("MatrattTypNavigation");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.MatrattProdukt", b =>
                {
                    b.HasOne("NackademinUppgift07.DataModels.Matratt", "Matratt")
                        .WithMany("MatrattProdukt")
                        .HasForeignKey("MatrattId")
                        .IsRequired()
                        .HasConstraintName("FK_MatrattProdukt_Matratt");

                    b.HasOne("NackademinUppgift07.DataModels.Produkt", "Produkt")
                        .WithMany("MatrattProdukt")
                        .HasForeignKey("ProduktId")
                        .IsRequired()
                        .HasConstraintName("FK_MatrattProdukt_Produkt");

                    b.Navigation("Matratt");

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.ApplicationUser", b =>
                {
                    b.Navigation("Bestallning");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.Bestallning", b =>
                {
                    b.Navigation("BestallningMatratt");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.Matratt", b =>
                {
                    b.Navigation("BestallningMatratt");

                    b.Navigation("MatrattProdukt");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.MatrattTyp", b =>
                {
                    b.Navigation("Matratt");
                });

            modelBuilder.Entity("NackademinUppgift07.DataModels.Produkt", b =>
                {
                    b.Navigation("MatrattProdukt");
                });
#pragma warning restore 612, 618
        }
    }
}