using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FitnessTracker.Models
{
    public class ActivityStatistic
    {
        public string name;
        public double y;
        public bool sliced = false;
        public bool selected = false;
        public void select(){
            this.sliced = true;
            this.selected = true;
        }
    }
}