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
    public class TireWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Tire> Tires { get; set; }

        private Tire selectedTire;

        public Tire SelectedTire
        {
            get { return selectedTire; }
            set
            {
                if (value != null)
                {
                    selectedTire = new Tire()
                    {
                        ID = value.ID,
                        TireName = value.TireName,
                        BrandID = value.BrandID,
                        Price = value.Price,
                        AspectRatio = value.AspectRatio,
                        Width = value.Width,
                        Diameter = value.Diameter
                        

                    };
                    OnPropertyChanged();
                    (DeleteTireCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateTireCommand { get; set; }

        public ICommand DeleteTireCommand { get; set; }

        public ICommand UpdateTireCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public TireWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Tires = new RestCollection<Tire>("http://localhost:53910/", "tire", "hub");
                CreateTireCommand = new RelayCommand(() =>
                {
                    Tires.Add(new Tire()
                    {
                        TireName = SelectedTire.TireName,
                        Price = SelectedTire.Price,
                        BrandID = SelectedTire.BrandID
                    });
                });

                UpdateTireCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Tires.Update(SelectedTire);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteTireCommand = new RelayCommand(() =>
                {
                    Tires.Delete(SelectedTire.ID);
                },
                () =>
                {
                    return SelectedTire != null;
                });
                SelectedTire = new Tire();
            }

        }
    }
}
