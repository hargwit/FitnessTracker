﻿// <auto-generated />
using System;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitnessTracker.Migrations
{
    [DbContext(typeof(FitnessTrackerWorkoutContext))]
    [Migration("20181101095523_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("FitnessTracker.Models.CardioWorkout", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Activity");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("DistanceKM");

                    b.Property<TimeSpan>("Time");

                    b.HasKey("ID");

                    b.ToTable("CardioWorkouts");
                });

            modelBuilder.Entity("FitnessTracker.Models.StrengthWorkout", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Activity");

                    b.Property<DateTime>("Date");

                    b.Property<int>("NumReps");

                    b.Property<decimal>("WeightKG");

                    b.HasKey("ID");

                    b.ToTable("StrengthWorkouts");
                });
#pragma warning restore 612, 618
        }
    }
}
