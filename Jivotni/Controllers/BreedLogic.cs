using Jivotni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jivotni.Controllers
{
    public class BreedLogic
    {
        private AnimalsContext _animalsContext = new AnimalsContext();
        public List<Bread>GetAllBreeds()
        {
            return _animalsContext.Breads.ToList();
        }
        public string GetBreadById(int id)
        {
            return _animalsContext.Breads.Find(id).Name;
        }
    }
}
