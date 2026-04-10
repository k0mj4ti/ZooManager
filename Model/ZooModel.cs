using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager.Model
{
    public class ZooModel
    {
        private List<Animal> _animals;
        public List<Animal> Animals => _animals;

        public ZooModel() {
            _animals = new List<Animal>();
            LoadFromFile("Model/animals.txt");
        }

        private void LoadFromFile(string path) {
            if (File.Exists(path)) {

                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines) {
                    string[] parts = line.Split(';');

                    if (parts.Length == 5) {
                        _animals.Add(new Animal(parts[0], parts[1], int.Parse(parts[2]), double.Parse(parts[3]), bool.Parse(parts[4])));
                    }

                }
            }
        }
        public void AddAnimal(Animal animal) {
            _animals.Add(animal);
        }

        public void RemoveAnimal(Animal animal)
        {
            _animals.Remove(animal);
        }
    }
}