﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSRESData;

namespace PSRESData.Migrations
{
    [DbContext(typeof(PSRESContext))]
    partial class PSRESContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PSRESData.Entities.MeterEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<long>("Serialcode");

                    b.HasKey("Id");

                    b.ToTable("Meters");
                });

            modelBuilder.Entity("PSRESData.Entities.MeterRecordingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MeterId");

                    b.Property<int>("activeEnergy");

                    b.Property<decimal>("current");

                    b.Property<int?>("datetimeId");

                    b.Property<decimal>("frequency");

                    b.Property<int>("peakActivePower");

                    b.Property<int>("peakReactivePower");

                    b.Property<decimal>("powerFactor");

                    b.Property<int>("reactiveEnergy");

                    b.Property<decimal>("voltage");

                    b.HasKey("Id");

                    b.HasIndex("MeterId");

                    b.HasIndex("datetimeId");

                    b.ToTable("MeterRecordings");
                });

            modelBuilder.Entity("PSRESData.Entities.SensorRecordingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Distance");

                    b.Property<double>("Illumination");

                    b.Property<bool>("Presence");

                    b.Property<int?>("SensoringStationEntityId");

                    b.Property<int>("SensoringStationId");

                    b.Property<double>("Temperature");

                    b.Property<int?>("TimeDateEntityId");

                    b.HasKey("Id");

                    b.HasIndex("SensoringStationEntityId");

                    b.HasIndex("TimeDateEntityId");

                    b.ToTable("SensorRecordings");
                });

            modelBuilder.Entity("PSRESData.Entities.SensoringStationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParentId");

                    b.Property<int>("ParentPin");

                    b.Property<int>("PositionId");

                    b.Property<int>("Zone");

                    b.HasKey("Id");

                    b.ToTable("SensoringStations");
                });

            modelBuilder.Entity("PSRESData.Entities.TimeDateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("day");

                    b.Property<byte>("hour");

                    b.Property<byte>("minute");

                    b.Property<byte>("month");

                    b.Property<byte>("year");

                    b.HasKey("Id");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("PSRESData.Entities.MeterRecordingEntity", b =>
                {
                    b.HasOne("PSRESData.Entities.MeterEntity", "meter")
                        .WithMany("Recording")
                        .HasForeignKey("MeterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PSRESData.Entities.TimeDateEntity", "datetime")
                        .WithMany("meterRecordings")
                        .HasForeignKey("datetimeId");
                });

            modelBuilder.Entity("PSRESData.Entities.SensorRecordingEntity", b =>
                {
                    b.HasOne("PSRESData.Entities.SensoringStationEntity")
                        .WithMany("Recordings")
                        .HasForeignKey("SensoringStationEntityId");

                    b.HasOne("PSRESData.Entities.TimeDateEntity")
                        .WithMany("sensorRecordings")
                        .HasForeignKey("TimeDateEntityId");
                });
#pragma warning restore 612, 618
        }
    }
}