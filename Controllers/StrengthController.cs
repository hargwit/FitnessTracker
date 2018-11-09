using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class StrengthController : Controller
    {
        private readonly FitnessTrackerWorkoutContext _context;

        public StrengthController(FitnessTrackerWorkoutContext context)
        {
            _context = context;
        }

        // GET: Strength
        public async Task<IActionResult> Index(string WorkoutActivity)
        {
            // Get all strength workouts without filter
            IQueryable<StrengthWorkout> strengthWorkouts = from w in _context.StrengthWorkouts
                                                       orderby w.Activity, w.NumReps
                                                       select w;
            // Variable for specific set of workouts
            IQueryable<StrengthWorkout> queryStrengthWorkouts;
            if (!String.IsNullOrEmpty(WorkoutActivity))
            {
                // Get specific set of workouts
                queryStrengthWorkouts = from w in _context.StrengthWorkouts
                                 orderby w.Activity, w.NumReps
                                 where w.Activity == WorkoutActivity
                                 select w;
            }
            else
            {
                // If no search string specified set the same
                queryStrengthWorkouts = strengthWorkouts;
            }
            // Get all available activities for filter dropdown
            IQueryable<string> activityQuery = from w in _context.StrengthWorkouts
                                               orderby w.Activity
                                               select w.Activity;
            // Load up the model
            var workoutActivityVM = new WorkoutActivityViewModel();
            workoutActivityVM.WorkoutActivity = WorkoutActivity;
            workoutActivityVM.Activities = new SelectList(await activityQuery.Distinct().ToListAsync());
            workoutActivityVM.StrengthWorkouts = await queryStrengthWorkouts.ToListAsync();
            workoutActivityVM.setStrengthStats(await strengthWorkouts.ToListAsync(), WorkoutActivity);
            workoutActivityVM.setStrengthPBs();
            
            return View(workoutActivityVM);
        }

        // GET: Strength/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strengthWorkout = await _context.StrengthWorkouts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (strengthWorkout == null)
            {
                return NotFound();
            }

            return View(strengthWorkout);
        }

        // GET: Strength/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Strength/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeightKG,NumReps,ID,Activity")] StrengthWorkout strengthWorkout)
        {
            strengthWorkout.Date = DateTime.Today;
            if (ModelState.IsValid)
            {
                _context.Add(strengthWorkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(strengthWorkout);
        }

        // GET: Strength/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strengthWorkout = await _context.StrengthWorkouts.FindAsync(id);
            if (strengthWorkout == null)
            {
                return NotFound();
            }
            return View(strengthWorkout);
        }

        // POST: Strength/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WeightKG,NumReps,ID,Activity,Date")] StrengthWorkout strengthWorkout)
        {
            if (id != strengthWorkout.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(strengthWorkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StrengthWorkoutExists(strengthWorkout.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(strengthWorkout);
        }

        // GET: Strength/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strengthWorkout = await _context.StrengthWorkouts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (strengthWorkout == null)
            {
                return NotFound();
            }

            return View(strengthWorkout);
        }

        // POST: Strength/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var strengthWorkout = await _context.StrengthWorkouts.FindAsync(id);
            _context.StrengthWorkouts.Remove(strengthWorkout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StrengthWorkoutExists(int id)
        {
            return _context.StrengthWorkouts.Any(e => e.ID == id);
        }
    }
}
