using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jivotni.Models
{
    public class Animal
    {
     public int Id { get; set; }
    public string Name { get; set; }
    public int Opisanie { get; set; }
    public int Age { get; set; }

    public int BreadId { get; set; } 
    public Bread Breads { get; set; }
    }
}
