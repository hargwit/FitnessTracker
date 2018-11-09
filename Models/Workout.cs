using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class Workout
    {
        public int ID { get; set; }
        public string Activity { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "Date completed")]
        public DateTime Date { get; set; }
        
    }
}