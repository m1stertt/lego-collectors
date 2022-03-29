using System.Collections.Generic;

namespace LegoCollectors.Core.Models
{
    public class Lego
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }
        
        public string Image { get; set; }
        
        public List<LegoStock> Stocks { get; set; }
    }
}