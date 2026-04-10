using ZooManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace ZooManager.ViewModel
{
    public class ZooViewModel : ViewModelBase
    {
        private ZooModel _model;
        private Animal? _selectedAnimal;
        private string _newName;
        private string _newSpecies;
        private int _newAge;
        private double _newWeight;
        private bool _newIsEndangered;

        public ObservableCollection<Animal> Animals { get; set; }

        public Animal? SelectedAnimal{
            get => _selectedAnimal;
            set { _selectedAnimal = value; OnPropertyChanged(nameof(SelectedAnimal));}
        }

        public string AnimalCount => $"Összes állat: {Animals.Count}, ebből veszélyeztetett: {Animals.Count(a => a.IsEndangered)}";

        public string NewName {
            get => _newName;
            set { _newName = value; OnPropertyChanged(nameof(NewName)); }
        }
        public string NewSpecies {
            get => _newSpecies;
            set { _newSpecies = value; OnPropertyChanged(nameof(NewSpecies)); }
        }
        public int NewAge {
            get => _newAge;
            set { _newAge = value; OnPropertyChanged(nameof(NewAge)); }
        }
        public double NewWeight {
            get => _newWeight;
            set { _newWeight = value; OnPropertyChanged(nameof(NewWeight)); }
        }
        public bool NewIsEndangered {
            get => _newIsEndangered;
            set { _newIsEndangered = value; OnPropertyChanged(nameof(NewIsEndangered)); }
        }

        public RelayCommand AddAnimalCommand { get; set; }
        public RelayCommand RemoveAnimalCommand { get; set; }

        public ZooViewModel(ZooModel model) {
            _model = model;
            Animals = new ObservableCollection<Animal>(_model.Animals);
            AddAnimalCommand = new RelayCommand(() => {
                Animal newAnimal = new Animal(NewName, NewSpecies, NewAge, NewWeight, NewIsEndangered);
                _model.AddAnimal(newAnimal);

                Animals.Add(newAnimal);

                OnPropertyChanged(nameof(AnimalCount));
            });

            RemoveAnimalCommand = new RelayCommand(() => {
                if (SelectedAnimal != null) {
                    _model.RemoveAnimal(SelectedAnimal);
                    Animals.Remove(SelectedAnimal);

                    SelectedAnimal = null;
                    OnPropertyChanged(nameof(AnimalCount));
                }
            });
        }
    }
}