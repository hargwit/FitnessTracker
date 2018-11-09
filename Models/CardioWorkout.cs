using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class CardioWorkout : Workout
    {
        [Display(Name = "Distance (km)")]
        public decimal DistanceKM { get; set; }
        [Display(Name = "Time")]
        public TimeSpan Time { get; set; }
    }
}