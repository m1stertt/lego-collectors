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
                    Title = "Test piece 1", 
                    Description= "This is a test description"
                };
                LegoEntity le2 = new LegoEntity
                {
                    Title = "Test piece 2", 
                    Description= "This is a test description"
                };
                mainContext.Legos.AddRange(le1,le2);
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