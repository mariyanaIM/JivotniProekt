using System.Collections.Generic;

namespace Jivotni.Models
{
    public class Bread
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Animal> Animals { get; set; }
    }
}