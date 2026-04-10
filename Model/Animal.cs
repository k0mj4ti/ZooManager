using CommunityToolkit.Mvvm.Input;
using ZooManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager.Model
{
    public class Animal : ViewModelBase
    {
        private string _name;
        private string _species;
        private int _age;
        private double _weight;
        private bool _isEndangered;
        public string Name {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Species {
            get => _species;
            set { _species = value; OnPropertyChanged(nameof(Species));}
        }

        public int Age {
            get => _age;
            set { _age = value; OnPropertyChanged(nameof(Age));}
        }

        public double Weight {
            get => _weight;
            set { _weight = value; OnPropertyChanged(nameof(Weight));
            }
        }

        public bool IsEndangered {
            get => _isEndangered;
            set { _isEndangered = value; OnPropertyChanged(nameof(IsEndangered));}
        }
        public Animal(string name, string species, int age, double weight, bool isEndangered)
        {
            _name = name;
            _species = species;
            _age = age;
            _weight = weight;
            _isEndangered = isEndangered;
        }
    }
}