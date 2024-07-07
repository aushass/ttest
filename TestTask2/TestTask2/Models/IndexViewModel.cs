using System;

namespace TestTask2.Models
{
    public class IndexViewModel
    {
        public IndexViewModel(IEnumerable<Dish> collection)
        {
            Dishes = collection;
        }

        public string? NameUser { get; set; } 
        public string? EmailUser { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
    }
}
