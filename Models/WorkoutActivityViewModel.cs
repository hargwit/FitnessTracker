using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FitnessTracker.Models
{
    public class WorkoutActivityViewModel
    {
        public List<CardioWorkout> CardioWorkouts;
        public List<StrengthWorkout> StrengthWorkouts;
        public SelectList Activities;
        public string WorkoutActivity { get; set; }
        public List<ActivityStatistic> CardioStats;
        public List<ActivityStatistic> StrengthStats;
        public List<CardioWorkout> CardioPersonalBests;
        public List<StrengthWorkout> StrengthPersonalBests;

        // Calculate proportion of each activity for pie charts
        public void setCardioStats(List<CardioWorkout> cardioWorkouts, string WorkoutActivity){
            // Create new list
            CardioStats = new List<ActivityStatistic>();
            // Loop variables
            ActivityStatistic statistic;
            int count = 1;
            bool first = true;
            string name = cardioWorkouts[0].Activity;
            // Loop through every Cardio workout
            foreach(CardioWorkout cardioWorkout in cardioWorkouts)
            {
                if(!first){
                    // Add count if same activity
                    if(cardioWorkout.Activity==name)
                    {
                        count++;
                    } 
                    // Create and load new statistic if not
                    else 
                    {
                        statistic = new ActivityStatistic();
                        statistic.name = name;
                        statistic.y = ((double)count)/((double)cardioWorkouts.Count);
                        // If activity matches query select it
                        if(statistic.name == WorkoutActivity)
                        {
                            statistic.select();
                        }
                        CardioStats.Add(statistic);
                        // Reset Loop variables
                        count = 1;
                        name = cardioWorkout.Activity;
                    }
                } else {
                    first = false;
                }
                
            }
            //Add final statistic
            statistic = new ActivityStatistic();
            statistic.name = name;
            statistic.y = ((double)count)/((double)cardioWorkouts.Count);
            // If activity matches query select it
            if(statistic.name == WorkoutActivity)
            {
                statistic.select();
            }
            CardioStats.Add(statistic);
        }

        // Calculate proportion of each activity for pie charts
        public void setStrengthStats(List<StrengthWorkout> strengthWorkouts, string WorkoutActivity){
            // Create new list
            StrengthStats = new List<ActivityStatistic>();
            // Loop variables
            ActivityStatistic statistic;
            int count = 1;
            bool first = true;
            string name = strengthWorkouts[0].Activity;
            // Loop through every Cardio workout
            foreach(StrengthWorkout cardioWorkout in strengthWorkouts)
            {
                if(!first){
                    // Add count if same activity
                    if(cardioWorkout.Activity==name)
                    {
                        count++;
                    } 
                    // Create and load new statistic if not
                    else 
                    {
                        statistic = new ActivityStatistic();
                        statistic.name = name;
                        statistic.y = ((double)count)/((double)strengthWorkouts.Count);
                        // If activity matches query select it
                        if(statistic.name == WorkoutActivity){
                            statistic.select();
                        }
                        StrengthStats.Add(statistic);
                        // Reset Loop variables
                        count = 1;
                        name = cardioWorkout.Activity;
                    }
                } else {
                    first = false;
                }
            }
            //Add final statistic
            statistic = new ActivityStatistic();
            statistic.name = name;
            statistic.y = ((double)count)/((double)strengthWorkouts.Count);
            // If activity matches query select it
            if(statistic.name == WorkoutActivity)
            {
                statistic.select();
            }
            StrengthStats.Add(statistic);
        }

        // Calculate personal bests for cardio activities
        public void setCardioPBs(){
            // Create new list of activities
            CardioPersonalBests = new List<CardioWorkout>();
            CardioWorkout best = CardioWorkouts[0];
            foreach(CardioWorkout cardioWorkout in CardioWorkouts)
            {
                // If same event
                if(cardioWorkout.Activity == best.Activity && cardioWorkout.DistanceKM == best.DistanceKM)
                {
                    // If a better time
                    if(cardioWorkout.Time<best.Time)
                    {
                        best = cardioWorkout;
                    }
                } 
                else 
                {
                    // Add to personal bests
                    CardioPersonalBests.Add(best);
                    best = cardioWorkout;
                }
            }
            CardioPersonalBests.Add(best);
        }

        // Calculate personal bests for strength activities
        public void setStrengthPBs(){
            // Create new list of activities
            StrengthPersonalBests = new List<StrengthWorkout>();
            StrengthWorkout best = StrengthWorkouts[0];
            foreach(StrengthWorkout strengthWorkout in StrengthWorkouts)
            {
                // If same event
                if(strengthWorkout.Activity == best.Activity && strengthWorkout.NumReps == best.NumReps)
                {
                    // If a better weight
                    if(strengthWorkout.WeightKG>best.WeightKG)
                    {
                        best = strengthWorkout;
                    }
                } 
                else 
                {
                    // Add to personal bests
                    StrengthPersonalBests.Add(best);
                    best = strengthWorkout;
                }
            }
            StrengthPersonalBests.Add(best);
        }
    }
}