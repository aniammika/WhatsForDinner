using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsForDinner.Data;
using WhatsForDinner.Model;

namespace WhatsForDinner.ViewModel
{
    public class DinnerViewModel: ViewModelBase
    {
        private readonly Dinner _dinner;
        private readonly IDinnerDataProvider _dinnerDataProvider;
        public bool IsEditMode { get; set; } = false;

        //constructor
        public DinnerViewModel(Dinner dinner, IDinnerDataProvider dinnerDataProvider)
        {
            _dinner = dinner;
            _dinnerDataProvider = dinnerDataProvider;
        }

        public string DinnerName
        {
            get => _dinner.DinnerName;
            set
            {
                if (_dinner.DinnerName != value)
                {
                    _dinner.DinnerName = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSave));
                }
            }
        }

        public bool IsDinnerFavourite
        {
            get => _dinner.IsFavourite;
            set
            {
                if (_dinner.IsFavourite != value)
                {
                    _dinner.IsFavourite = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DinnerDescription
        {
            get => _dinner.Description;
            set
            {
                if (_dinner.Description != value)
                {
                    _dinner.Description = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DinnerRecipeURL
        {
            get => _dinner.RecipeURL;
            set
            {
                if (_dinner.RecipeURL != value)
                {
                    _dinner.RecipeURL = value;
                    RaisePropertyChanged();
                }
            }
        }

        //TODO: check if added tag exists already
        public string DinnerTags
        {
            get => _dinner.DinnerTags.ToString();
            set { _dinner.DinnerTags.Add(value); }
        }

        public int CusineId
        {
            get => _dinner.CusineId;
            set
            {
                if (_dinner.CusineId != value)
                {
                    _dinner.CusineId = value;
                    RaisePropertyChanged();
                }
            }
        }


        public bool CanSave => !string.IsNullOrEmpty(DinnerName);

        public void Save()
        {
            _dinnerDataProvider.SaveDinner(_dinner);
        }

        public void Edit()
        {
            IsEditMode = true;
        }
    }
}
