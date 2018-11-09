using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessTracker.Models
{
    public class WorkoutChartViewModel
    {
        public List<WorkoutEvent> CardioEvents;
        public List<WorkoutEvent> StrengthEvents;
        public SelectList CardioActivities;
        public SelectList StrengthActivities;
        public string CardioActivity;
        public string StrengthActivity;
        public WorkoutChartViewModel(List<CardioWorkout> cardioWorkouts, List<StrengthWorkout> strengthWorkouts)
        {
            // Load all events
            loadCardio(cardioWorkouts);
            loadStrength(strengthWorkouts);
        }

        // Load cardio events into object
        public void loadCardio(List<CardioWorkout> cardioWorkouts)
        {
            // Create new list
            CardioEvents = new List<WorkoutEvent>();
            //If there are any cardio workouts
            if (cardioWorkouts.Count > 0)
            {
                // Create workout event string
                string workout = cardioWorkouts[0].Activity + " - " + cardioWorkouts[0].DistanceKM + "km";
                // Create new workout event
                WorkoutEvent workoutEvent = new WorkoutEvent(workout);
                // Add date and timespan to event
                workoutEvent.Add(new Object[] {((DateTimeOffset)cardioWorkouts[0].Date).ToUnixTimeMilliseconds(), cardioWorkouts[0].Time.TotalMilliseconds});
                bool first = true;
                foreach (CardioWorkout cardioWorkout in cardioWorkouts)
                {
                    if (!first)
                    {
                        // Create workout string
                        workout = cardioWorkout.Activity + " - " + cardioWorkout.DistanceKM + "km";
                        // If different event
                        if (workout != workoutEvent.Name)
                        {
                            // Add to workout event list
                            CardioEvents.Add(workoutEvent);
                            // Reset event
                            workoutEvent = new WorkoutEvent(workout);
                        }
                        // Add date and timespan to event
                        workoutEvent.Add(new Object[] {((DateTimeOffset)cardioWorkout.Date).ToUnixTimeMilliseconds(), cardioWorkout.Time.TotalMilliseconds});
                    } 
                    else 
                    {
                        first = false;
                    }
                    
                }
                // Add final event to list
                CardioEvents.Add(workoutEvent);
            }

        }
        // Load strength events into object
        public void loadStrength(List<StrengthWorkout> strengthWorkouts)
        {
            // Create new list
            StrengthEvents = new List<WorkoutEvent>();
            //If there are any strength workouts
            if (strengthWorkouts.Count > 0)
            {
                // Create workout event string
                string workout = strengthWorkouts[0].Activity + " - " + strengthWorkouts[0].NumReps + " rep(s)";
                // Create new workout event
                WorkoutEvent workoutEvent = new WorkoutEvent(workout);
                // Add date and timespan to event
                workoutEvent.Add(new Object[] {((DateTimeOffset)strengthWorkouts[0].Date).ToUnixTimeMilliseconds(), strengthWorkouts[0].WeightKG});
                int i = 0;
                foreach (StrengthWorkout strengthWorkout in strengthWorkouts)
                {
                    if (i > 0)
                    {
                        // Create workout string
                        workout = strengthWorkout.Activity + " - " + strengthWorkout.NumReps + " rep(s)";
                        // If different event
                        if (workout != workoutEvent.Name)
                        {
                            // Add to workout event list
                            StrengthEvents.Add(workoutEvent);
                            // Reset event
                            workoutEvent = new WorkoutEvent(workout);
                        }
                        // Add date and timespan to event
                        workoutEvent.Add(new Object[] {((DateTimeOffset)strengthWorkout.Date).ToUnixTimeMilliseconds(), strengthWorkout.WeightKG});
                    } 
                    else
                    {
                        i++;
                    }
                }
                // Add final event to list
                StrengthEvents.Add(workoutEvent);
            }

        }

    }
}