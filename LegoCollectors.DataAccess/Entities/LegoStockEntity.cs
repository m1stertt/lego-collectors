using LegoCollectors.Security.Model;

namespace LegoCollectors.DataAccess.Entities
{
    public class LegoStockEntity
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public LoginUser User { get; set; }
    }
}