using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Models
{
    public class FitnessTrackerWorkoutContext : DbContext
    {
        public FitnessTrackerWorkoutContext (DbContextOptions<FitnessTrackerWorkoutContext> options)
            : base(options)
        {
        }

        public DbSet<FitnessTracker.Models.CardioWorkout> CardioWorkouts { get; set; }
        public DbSet<FitnessTracker.Models.StrengthWorkout> StrengthWorkouts { get; set; }
        
    }
}