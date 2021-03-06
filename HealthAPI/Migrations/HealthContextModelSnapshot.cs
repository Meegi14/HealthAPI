﻿// <auto-generated />
using HealthAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthAPI.Migrations
{
    [DbContext(typeof(HealthContext))]
    partial class HealthContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HealthAPI.Models.Ailment", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PatientId");

                    b.HasKey("Name");

                    b.HasIndex("PatientId");

                    b.ToTable("Aliments");
                });

            modelBuilder.Entity("HealthAPI.Models.Medication", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Doses");

                    b.Property<string>("PatientId");

                    b.HasKey("Name");

                    b.HasIndex("PatientId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("HealthAPI.Models.Patient", b =>
                {
                    b.Property<string>("PatientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HealthAPI.Models.Ailment", b =>
                {
                    b.HasOne("HealthAPI.Models.Patient")
                        .WithMany("Aliments")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("HealthAPI.Models.Medication", b =>
                {
                    b.HasOne("HealthAPI.Models.Patient")
                        .WithMany("Medications")
                        .HasForeignKey("PatientId");
                });
#pragma warning restore 612, 618
        }
    }
}
