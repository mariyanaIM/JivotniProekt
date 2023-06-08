using Jivotni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Jivotni.Controllers
{
    public class AnimalLogic
    {
        private AnimalsContext _animalsContext = new AnimalsContext();
        public Animal Get(int id)
        {
            Animal findedAnimal = _animalsContext.Animals.Find(id);
            if (findedAnimal!=null)
            {
                _animalsContext.Entry(findedAnimal).Reference(x => x.Breads).Load();
            }
            return findedAnimal;
        }
        public List<Animal> GetAll()
        {
            return _animalsContext.Animals.Include("Breads").ToList();
        }
        public void Create (Animal animal)
        {
            _animalsContext.Animals.Add(animal);
            _animalsContext.SaveChanges();
        }
        public void Update (int id, Animal animal)
        {
            Animal findedAnimal = _animalsContext.Animals.Find(id);
            if (findedAnimal==null)
            {
                return;
            }
            //findedAnimal.Id = animal.Id;
            findedAnimal.Name = animal.Name;
            findedAnimal.Opisanie = animal.Opisanie;
            findedAnimal.Age=animal.Age;
            findedAnimal.BreadId = animal.BreadId;
            _animalsContext.SaveChanges();
        }
        public void Delete (int id)
        {
            Animal findedAnimal = _animalsContext.Animals.Find(id);
            _animalsContext.Animals.Remove(findedAnimal);
            _animalsContext.SaveChanges();
        }
    }
}
