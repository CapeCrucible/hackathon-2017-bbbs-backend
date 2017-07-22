using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AspNetCoreWebService.Context;

namespace AspNetCoreWebService.Migrations
{
    [DbContext(typeof(bbbsDbContext))]
    [Migration("20170722210733_create-migration")]
    partial class createmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.BigLittleParentMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BigId");

                    b.Property<int>("LittleParentMapId");

                    b.HasKey("Id");

                    b.HasIndex("BigId");

                    b.HasIndex("LittleParentMapId");

                    b.ToTable("BigLittleParentMaps");
                });

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("UserAccountId");

                    b.Property<int>("UserAddressId");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId");

                    b.HasIndex("UserAddressId");

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InterestName");

                    b.HasKey("Id");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.InterestUserMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InterestId");

                    b.Property<int>("UserAccountId");

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("InterestUserMaps");
                });

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.LittleParentMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LittleId");

                    b.Property<int>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("LittleId");

                    b.HasIndex("ParentId");

                    b.ToTable("LittleParentMaps");
                });

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.Property<int>("UserTypeId");

                    b.HasKey("Id");

                    b.HasIndex("UserTypeId");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("State")
                        .HasMaxLength(2);

                    b.Property<string>("StreetLine1");

                    b.Property<string>("StreetLine2");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserTypeName");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.BigLittleParentMap", b =>
                {
                    b.HasOne("AspNetCoreWebService.Context.Models.UserAccount", "UserAccount")
                        .WithMany()
                        .HasForeignKey("BigId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspNetCoreWebService.Context.Models.LittleParentMap", "LittleParentMap")
                        .WithMany()
                        .HasForeignKey("LittleParentMapId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.ContactInfo", b =>
                {
                    b.HasOne("AspNetCoreWebService.Context.Models.UserAccount", "UserAccount")
                        .WithMany()
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspNetCoreWebService.Context.Models.UserAddress", "UserAddress")
                        .WithMany()
                        .HasForeignKey("UserAddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.InterestUserMap", b =>
                {
                    b.HasOne("AspNetCoreWebService.Context.Models.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspNetCoreWebService.Context.Models.UserAccount", "UserAccount")
                        .WithMany()
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.LittleParentMap", b =>
                {
                    b.HasOne("AspNetCoreWebService.Context.Models.UserAccount", "Little")
                        .WithMany()
                        .HasForeignKey("LittleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspNetCoreWebService.Context.Models.UserAccount", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspNetCoreWebService.Context.Models.UserAccount", b =>
                {
                    b.HasOne("AspNetCoreWebService.Context.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
