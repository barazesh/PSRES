﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSRES.Data;

namespace PSRES.Data.Migrations
{
    [DbContext(typeof(PSRESContext))]
    [Migration("20181106112924_addsesnors")]
    partial class addsesnors
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PSRESLogic.Meter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<long>("Serialcode");

                    b.HasKey("Id");

                    b.ToTable("Meters");
                });

            modelBuilder.Entity("PSRESLogic.MeterRecording", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MeterId");

                    b.Property<int>("TimeDateId");

                    b.Property<decimal>("activeEnergy");

                    b.Property<int>("activePower");

                    b.Property<decimal>("current");

                    b.Property<decimal>("frequency");

                    b.Property<decimal>("powerFactor");

                    b.Property<decimal>("reactiveEnergy");

                    b.Property<int>("reactivePower");

                    b.Property<decimal>("voltage");

                    b.HasKey("Id");

                    b.HasIndex("MeterId");

                    b.HasIndex("TimeDateId");

                    b.ToTable("MeterRecordings");
                });

            modelBuilder.Entity("PSRESLogic.SensoringStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Light");

                    b.Property<int>("ParentId");

                    b.Property<int>("ParentPin");

                    b.Property<bool>("Presence");

                    b.Property<bool>("Temperature");

                    b.Property<int>("Zone");

                    b.Property<bool>("distance");

                    b.HasKey("Id");

                    b.ToTable("SensoringStations");
                });

            modelBuilder.Entity("PSRESLogic.SensorRecording", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Distance");

                    b.Property<double>("Illumination");

                    b.Property<bool>("Presence");

                    b.Property<int>("SensoringStationId");

                    b.Property<double>("Temperature");

                    b.Property<int>("TimeDateId");

                    b.HasKey("Id");

                    b.ToTable("SensorRecordings");
                });

            modelBuilder.Entity("PSRESLogic.TimeDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("day");

                    b.Property<byte>("hour");

                    b.Property<byte>("minute");

                    b.Property<byte>("month");

                    b.Property<int>("year");

                    b.HasKey("Id");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("PSRESLogic.MeterRecording", b =>
                {
                    b.HasOne("PSRESLogic.Meter", "meter")
                        .WithMany("Recording")
                        .HasForeignKey("MeterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PSRESLogic.TimeDate", "datetime")
                        .WithMany("Recordings")
                        .HasForeignKey("TimeDateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}