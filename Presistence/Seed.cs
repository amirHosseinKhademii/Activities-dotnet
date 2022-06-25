using Domain;

namespace Presistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Activities.Any()) return;

            var activities = new List<Activity> {
                new Activity{
                    Title = "Past Activity 1",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Activity 2 months ago",
                    Category = "drinks",
                    City = "London",
                    Venue = "Pub",
                },
                   new Activity{
                    Title = "Past Activity 2",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Activity 3 months ago",
                    Category = "drinks2",
                    City = "London2",
                    Venue = "Pub2",
                }
            };

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
};