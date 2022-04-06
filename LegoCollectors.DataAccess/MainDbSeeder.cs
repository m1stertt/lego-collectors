using System.Collections.Generic;
using LegoCollectors.DataAccess.Entities;
using LegoCollectors.Security.Model;

namespace LegoCollectors.DataAccess
{
    public class MainDbSeeder : IMainDbSeeder
    {
        private readonly MainDbContext mainContext;

        public MainDbSeeder(MainDbContext ctx)
        {
            mainContext = ctx;
        }

        public void SeedDevelopment()
        {

                mainContext.Database.EnsureDeleted();
                mainContext.Database.EnsureCreated();
                mainContext.SaveChanges();
                LegoEntity le1 = new LegoEntity
                {
                    Name = "Test Shuttle",
                    Year = 1999,
                    Number_Parts = 21,
                    Image = "https://cdn.rebrickable.com/media/sets/3067-1/13934.jpg",
                    OwnerId = 1,
                    Amount=1,
                    Set_Number = "3067-1"
                };
                mainContext.Legos.Add(le1);
                mainContext.SaveChanges();
        }

        public void SeedProduction()
        {
            // For now. Should be fixed for production ready code.
                mainContext.Database.EnsureDeleted();
                
                mainContext.Database.EnsureCreated();
                mainContext.SaveChanges();
        }
    }
}