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