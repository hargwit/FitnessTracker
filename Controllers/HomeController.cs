using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Models;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        private readonly FitnessTrackerWorkoutContext _context;

        public HomeController(FitnessTrackerWorkoutContext context)
        {
            _context = context;
        }

        // GET: / or /Home/
        public async Task<IActionResult> Index(string CardioActivity, string StrengthActivity)
        {
            // Get Cardio workouts
            IOrderedQueryable<CardioWorkout> cardioWorkouts;
            if (!String.IsNullOrEmpty(CardioActivity))
            {
                // Filter cardio workouts
                cardioWorkouts = from w in _context.CardioWorkouts
                                 where w.Activity == CardioActivity
                                 orderby w.DistanceKM, w.Date
                                 select w;
            }
            else
            {
                // Get all cardio workouts
                cardioWorkouts = from w in _context.CardioWorkouts
                                 orderby w.Activity, w.DistanceKM, w.Date
                                 select w;
            }
            // Get Strength workouts
            IOrderedQueryable<StrengthWorkout> strengthWorkouts;
            if (!String.IsNullOrEmpty(StrengthActivity))
            {
                // Filter strength workouts
                strengthWorkouts = from w in _context.StrengthWorkouts
                                   where w.Activity == StrengthActivity
                                   orderby w.NumReps, w.Date
                                   select w;
            }
            else
            {
                // Get all strength workouts
                strengthWorkouts = from w in _context.StrengthWorkouts
                                   orderby w.Activity, w.NumReps, w.Date
                                   select w;
            }

            // Get cardio activity list
            IQueryable<string> cardioActivityQuery = from w in _context.CardioWorkouts
                                               orderby w.Activity
                                               select w.Activity;
            // Get strength activity list
            IQueryable<string> strengthActivityQuery = from w in _context.StrengthWorkouts
                                               orderby w.Activity
                                               select w.Activity;

            // Load the model
            var workoutChartVM = new WorkoutChartViewModel(await cardioWorkouts.ToListAsync(), await strengthWorkouts.ToListAsync());
            workoutChartVM.CardioActivity = CardioActivity;
            workoutChartVM.StrengthActivity = StrengthActivity;
            workoutChartVM.CardioActivities = new SelectList(await cardioActivityQuery.Distinct().ToListAsync());
            workoutChartVM.StrengthActivities = new SelectList(await strengthActivityQuery.Distinct().ToListAsync());
            
            return View(workoutChartVM);
        }
    }
}