namespace LegoCollectors.Security
{
    public interface IAuthDbSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}