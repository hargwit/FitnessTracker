using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class StrengthWorkout : Workout
    {
        [Display(Name = "Weight (kg)")]
        public decimal WeightKG { get; set; }
        [Display(Name = "Number of Reps")]
        public int NumReps { get; set; }
    }
}