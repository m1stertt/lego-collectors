namespace LegoCollectors.DataAccess
{
    public interface IMainDbSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}