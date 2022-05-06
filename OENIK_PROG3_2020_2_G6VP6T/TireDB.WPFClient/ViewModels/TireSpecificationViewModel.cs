using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TireShop.Data;
using TireShop.Data.Tables;
using TrieDB.WPFClient;

namespace TireDB.WPFClient.ViewModels
{
    public class TireSpecificationViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<TireSpecification> TireSepcs { get; set; }

        private TireSpecification selectedTireSpec;

        public TireSpecification SelectedTireSpec
        {
            get { return selectedTireSpec; }
            set
            {
                if (value != null)
                {
                    selectedTireSpec = new TireSpecification()
                    {
                        ID = value.ID,
                        TireID = value.TireID,
                        LoadIndex = value.LoadIndex,
                        ProductionCountryName = value.ProductionCountryName,
                        ProductionWeek = value.ProductionWeek,
                        ProductionYear = value.ProductionYear,
                        DOTNumber = value.DOTNumber,
                        SpeedRating = value.SpeedRating
                    };
                    OnPropertyChanged();
                    (DeleteTireSpecCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateTireSpecCommand { get; set; }

        public ICommand DeleteTireSpecCommand { get; set; }

        public ICommand UpdateTireSpecCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public TireSpecificationViewModel()
        {
            if (!IsInDesignMode)
            {
                TireSepcs = new RestCollection<TireSpecification>("http://localhost:53910/", "TireSpecification", "hub");
                CreateTireSpecCommand = new RelayCommand(() =>
                {
                    TireSepcs.Add(new TireSpecification()
                    {
                        TireID = SelectedTireSpec.TireID,
                        DOTNumber = SelectedTireSpec.DOTNumber
                    });
                });

                UpdateTireSpecCommand = new RelayCommand(() =>
                {
                    try
                    {
                        TireSepcs.Update(SelectedTireSpec);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteTireSpecCommand = new RelayCommand(() =>
                {
                    TireSepcs.Delete(SelectedTireSpec.ID);
                },
                () =>
                {
                    return SelectedTireSpec != null;
                });
                SelectedTireSpec = new TireSpecification();
            }

        }
    }
}
