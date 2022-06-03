using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsForDinner.Data;
using WhatsForDinner.Model;

namespace WhatsForDinner.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private DinnerViewModel _selectedDinner;
        private readonly IDinnerDataProvider _dinnerDataProvider;

        public MainViewModel(IDinnerDataProvider dinnerDataProvider)
        {
            _dinnerDataProvider = dinnerDataProvider;
        }
        public ObservableCollection<DinnerViewModel> Dinners { get; } = new();
        public ObservableCollection<Cusine> Cusines { get; } = new();
        public DinnerViewModel SelectedDinner
        {
            get => _selectedDinner;
            set
            {
                if (_selectedDinner != value)
                {
                    _selectedDinner = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsDinnerSelected));
                }
            }
        }
        public bool IsDinnerSelected => _selectedDinner != null;

        public async Task LoadAsync()
        {
            if (Dinners.Any())
            {
                return;
            }

            var dinners = _dinnerDataProvider.LoadDinners();
            var cusines = _dinnerDataProvider.LoadCusines();

            Dinners.Clear();
            foreach (var dinner in dinners)
            {
                Dinners.Add(new DinnerViewModel(dinner, _dinnerDataProvider));
            }

            Cusines.Clear();
            foreach (var cusine in cusines)
            {
                Cusines.Add(cusine);
            }
        }

        private void Add(object? parameter)
        {
            var dinner = new Dinner { DinnerName = "New" };
            var dinnerViewModel = new DinnerViewModel(dinner, _dinnerDataProvider);
            Dinners.Add(dinnerViewModel);
            SelectedDinner = dinnerViewModel;
            _dinnerDataProvider.AddDinner(dinner);
        }

        public void GetRandomDinner()
        {
            Random rnd = new Random();
            var dinners = _dinnerDataProvider.LoadDinners();

            Dinners.Clear();
            foreach (var dinner in dinners)
            {
                Dinners.Add(new DinnerViewModel(dinner, _dinnerDataProvider));
            }
            var randomDinner = Dinners[rnd.Next(Dinners.Count)];
            SelectedDinner = randomDinner;
        }



        private void Delete(object? parameter)
        {
            if (SelectedDinner is not null)
            {
                Dinners.Remove(SelectedDinner);
                var dinners = _dinnerDataProvider.LoadDinners();
                var dinnerToRemove = dinners.Find(x => x.DinnerName == SelectedDinner.DinnerName);
                _dinnerDataProvider.RemoveDinner(dinnerToRemove);
                SelectedDinner = null;
            }
        }

        private bool CanDelete(object? parameter) => SelectedDinner is not null;
    }
}
