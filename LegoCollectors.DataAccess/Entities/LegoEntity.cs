using System.Collections.Generic;

namespace LegoCollectors.DataAccess.Entities
{
    public class LegoEntity
    {
        public int Id { get; set; }
        
        public string Set_Number { get; set; }
        public string Name { get; set; }

        public int Year { get; set; }
        
        public int Number_Parts { get; set; }
        
        public int OwnerId { get; set; }
        
        public string Image { get; set; }
        
        public int Amount { get; set; }
    }
}