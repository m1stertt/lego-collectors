using LegoCollectors.Security.Model;

namespace LegoCollectors.Core.Models
{
    public class LegoStock
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Lego Lego { get; set; }
        public LoginUser User { get; set; }
    }
}