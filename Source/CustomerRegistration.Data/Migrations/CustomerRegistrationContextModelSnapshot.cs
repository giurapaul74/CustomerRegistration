﻿// <auto-generated />
using CustomerRegistration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerRegistration.Data.Migrations
{
    [DbContext(typeof(CustomerRegistrationContext))]
    partial class CustomerRegistrationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerRegistration.Data.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "DC",
                            Country = "US",
                            Number = 56,
                            PostalCode = "762853",
                            Street = "New Wantons"
                        },
                        new
                        {
                            Id = 2,
                            City = "New Orleans",
                            Country = "US",
                            Number = 543,
                            PostalCode = "358394",
                            Street = "Checkery Street"
                        });
                });

            modelBuilder.Entity("CustomerRegistration.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceAddressId");

                    b.HasIndex("PostalAddressId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmailAddress = "chr.undr@gmail.com",
                            InvoiceAddressId = 1,
                            Name = "Christian Undertow",
                            PhoneNumber = "555-1745-9745",
                            PostalAddressId = 1,
                            Website = "www.nonewrelevance.com"
                        },
                        new
                        {
                            Id = 2,
                            EmailAddress = "pl.blrt@gmail.com",
                            InvoiceAddressId = 2,
                            Name = "Paul Blart",
                            PhoneNumber = "555-8474-1732",
                            PostalAddressId = 2,
                            Website = "www.emtspecials.com"
                        });
                });

            modelBuilder.Entity("CustomerRegistration.Data.Customer", b =>
                {
                    b.HasOne("CustomerRegistration.Data.Address", "InvoiceAddress")
                        .WithMany()
                        .HasForeignKey("InvoiceAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerRegistration.Data.Address", "PostalAddress")
                        .WithMany()
                        .HasForeignKey("PostalAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceAddress");

                    b.Navigation("PostalAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
