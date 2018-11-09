using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FitnessTracker.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessTrackerWorkoutContext(
                serviceProvider.GetRequiredService<DbContextOptions<FitnessTrackerWorkoutContext>>()))
            {
                // Look for any workouts
                if (context.CardioWorkouts.Any() || context.StrengthWorkouts.Any())
                {
                    return;   // DB has been seeded
                }

                // Cardio Workouts seeds
                context.CardioWorkouts.AddRange(
                    new CardioWorkout
                    {
                        Activity = "Run",
                        DistanceKM = 5.0M,
                        Time = new TimeSpan(0, 40, 20),
                        Date = DateTime.Parse("2018-1-2"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Run",
                        DistanceKM = 5.0M,
                        Time = new TimeSpan(0, 38, 18),
                        Date = DateTime.Parse("2018-2-5"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Run",
                        DistanceKM = 5.0M,
                        Time = new TimeSpan(0, 35, 0),
                        Date = DateTime.Parse("2018-3-10"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Run",
                        DistanceKM = 5.0M,
                        Time = new TimeSpan(0, 30, 18),
                        Date = DateTime.Parse("2018-4-5"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Run",
                        DistanceKM = 5.0M,
                        Time = new TimeSpan(0, 23, 12),
                        Date = DateTime.Parse("2018-5-20"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Run",
                        DistanceKM = 10.0M,
                        Time = new TimeSpan(1, 02, 01),
                        Date = DateTime.Parse("2018-3-15"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Run",
                        DistanceKM = 10.0M,
                        Time = new TimeSpan(0, 50, 45),
                        Date = DateTime.Parse("2018-4-15"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Run",
                        DistanceKM = 10.0M,
                        Time = new TimeSpan(0, 55, 12),
                        Date = DateTime.Parse("2018-5-21"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Run",
                        DistanceKM = 10.0M,
                        Time = new TimeSpan(0, 45, 03),
                        Date = DateTime.Parse("2018-6-20"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Row",
                        DistanceKM = 0.4M,
                        Time = new TimeSpan(0, 2, 03),
                        Date = DateTime.Parse("2018-1-15"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Row",
                        DistanceKM = 0.4M,
                        Time = new TimeSpan(0, 1, 45),
                        Date = DateTime.Parse("2018-3-20"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Row",
                        DistanceKM = 0.4M,
                        Time = new TimeSpan(0, 1, 33),
                        Date = DateTime.Parse("2018-4-25"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Row",
                        DistanceKM = 0.4M,
                        Time = new TimeSpan(0, 1, 35),
                        Date = DateTime.Parse("2018-6-5"),
                    },

                    new CardioWorkout
                    {
                        Activity = "Row",
                        DistanceKM = 0.4M,
                        Time = new TimeSpan(0, 1, 29),
                        Date = DateTime.Parse("2018-7-29"),
                    }
                );

                // Strength Workouts seeds
                context.StrengthWorkouts.AddRange(
                    new StrengthWorkout
                    {
                        Activity = "Bench",
                        WeightKG = 62.5M,
                        NumReps = 1,
                        Date = DateTime.Parse("2018-3-27"),
                    },

                    new StrengthWorkout
                    {
                        Activity = "Bench",
                        WeightKG = 67.5M,
                        NumReps = 1,
                        Date = DateTime.Parse("2018-5-15"),
                    },

                    new StrengthWorkout
                    {
                        Activity = "Bench",
                        WeightKG = 70.0M,
                        NumReps = 1,
                        Date = DateTime.Parse("2018-7-2"),
                    },

                    new StrengthWorkout
                    {
                        Activity = "Bench",
                        WeightKG = 75.0M,
                        NumReps = 1,
                        Date = DateTime.Parse("2018-8-19"),
                    },

                    new StrengthWorkout
                    {
                        Activity = "Bench",
                        WeightKG = 50.0M,
                        NumReps = 2,
                        Date = DateTime.Parse("2018-2-20"),
                    },

                    new StrengthWorkout
                    {
                        Activity = "Bench",
                        WeightKG = 55.0M,
                        NumReps = 2,
                        Date = DateTime.Parse("2018-4-12"),
                    },

                    new StrengthWorkout
                    {
                        Activity = "Bench",
                        WeightKG = 60.0M,
                        NumReps = 2,
                        Date = DateTime.Parse("2018-4-29"),
                    },

                    new StrengthWorkout
                    {
                        Activity = "Bench",
                        WeightKG = 67.5M,
                        NumReps = 2,
                        Date = DateTime.Parse("2018-5-20"),
                    },

                    new StrengthWorkout
                    {
                        Activity = "DeadLift",
                        WeightKG = 140.0M,
                        NumReps = 3,
                        Date = DateTime.Parse("2018-4-10"),
                    },

                   new StrengthWorkout
                   {
                       Activity = "DeadLift",
                       WeightKG = 142.5M,
                       NumReps = 3,
                       Date = DateTime.Parse("2018-5-3"),
                   },

                   new StrengthWorkout
                    {
                        Activity = "DeadLift",
                        WeightKG = 140.0M,
                        NumReps = 3,
                        Date = DateTime.Parse("2018-5-15"),
                    },

                   new StrengthWorkout
                   {
                       Activity = "DeadLift",
                       WeightKG = 145.0M,
                       NumReps = 3,
                       Date = DateTime.Parse("2018-6-8"),
                   },

                   new StrengthWorkout
                   {
                       Activity = "Clean",
                       WeightKG = 85.0M,
                       NumReps = 1,
                       Date = DateTime.Parse("2018-2-1"),
                   },

                   new StrengthWorkout
                   {
                       Activity = "Clean",
                       WeightKG = 92.5M,
                       NumReps = 1,
                       Date = DateTime.Parse("2018-4-5"),
                   }
                );

                context.SaveChanges();
            }
        }
    }
}