using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FitnessTracker.Models
{
    public class WorkoutEvent 
    {
        public string Name;
        public List<Object[]> Data;
        

        public WorkoutEvent(String Name){
            this.Name = Name;
            this.Data = new List<Object[]>();
        }

        public void Add(Object[] vals){
            Data.Add(vals);
        }

        
    }

}