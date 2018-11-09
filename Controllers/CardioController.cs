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
    public class CardioController : Controller
    {
        private readonly FitnessTrackerWorkoutContext _context;

        public CardioController(FitnessTrackerWorkoutContext context)
        {
            _context = context;
        }

        // GET: Cardio
        public async Task<IActionResult> Index(string WorkoutActivity)
        {
            // Get all cardio workouts without filter
            IQueryable<CardioWorkout> cardioWorkouts = from w in _context.CardioWorkouts
                                                       orderby w.Activity, w.DistanceKM
                                                       select w;
            // Variable for specific set of workouts
            IQueryable<CardioWorkout> queryCardioWorkouts;
            if (!String.IsNullOrEmpty(WorkoutActivity))
            {
                // Get specific set of workouts
                queryCardioWorkouts = from w in _context.CardioWorkouts
                                 orderby w.Activity, w.DistanceKM
                                 where w.Activity == WorkoutActivity
                                 select w;
            }
            else
            {
                // If no search string specified set the same
                queryCardioWorkouts = cardioWorkouts;
            }
            // Get all available activities for filter dropdown
            IQueryable<string> activityQuery = from w in _context.CardioWorkouts
                                               orderby w.Activity
                                               select w.Activity;
            // Load up the model
            var workoutActivityVM = new WorkoutActivityViewModel();
            workoutActivityVM.WorkoutActivity = WorkoutActivity;
            workoutActivityVM.Activities = new SelectList(await activityQuery.Distinct().ToListAsync());
            workoutActivityVM.CardioWorkouts = await queryCardioWorkouts.ToListAsync();
            workoutActivityVM.setCardioStats(await cardioWorkouts.ToListAsync(), WorkoutActivity);
            workoutActivityVM.setCardioPBs();
            
            return View(workoutActivityVM);
        }

        // GET: Cardio/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardioWorkout = await _context.CardioWorkouts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cardioWorkout == null)
            {
                return NotFound();
            }

            return View(cardioWorkout);
        }

        // GET: Cardio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cardio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistanceKM,Time,ID,Activity")] CardioWorkout cardioWorkout)
        {
            cardioWorkout.Date = DateTime.Today;
            if (ModelState.IsValid)
            {
                _context.Add(cardioWorkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardioWorkout);
        }

        // GET: Cardio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardioWorkout = await _context.CardioWorkouts.FindAsync(id);
            if (cardioWorkout == null)
            {
                return NotFound();
            }
            return View(cardioWorkout);
        }

        // POST: Cardio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DistanceKM,Time,ID,Activity,Date")] CardioWorkout cardioWorkout)
        {
            if (id != cardioWorkout.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardioWorkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardioWorkoutExists(cardioWorkout.ID))
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
            return View(cardioWorkout);
        }

        // GET: Cardio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardioWorkout = await _context.CardioWorkouts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cardioWorkout == null)
            {
                return NotFound();
            }

            return View(cardioWorkout);
        }

        // POST: Cardio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardioWorkout = await _context.CardioWorkouts.FindAsync(id);
            _context.CardioWorkouts.Remove(cardioWorkout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardioWorkoutExists(int id)
        {
            return _context.CardioWorkouts.Any(e => e.ID == id);
        }
    }
}
