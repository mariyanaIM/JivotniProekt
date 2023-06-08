using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jivotni.Models
{
    public class AnimalsContext:DbContext
    {
        public AnimalsContext() : base("AnimalsContext")
        {

        }
        public DbSet<Animal> Animals { get; set; } //table DOGS
        public DbSet<Bread> Breads { get; set; }
    }
}
