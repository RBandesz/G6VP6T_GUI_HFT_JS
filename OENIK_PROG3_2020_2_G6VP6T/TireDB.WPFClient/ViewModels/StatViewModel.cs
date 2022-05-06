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
using System.Runtime.CompilerServices;
using TireShop.Logic;

namespace TireDB.WPFClient.ViewModels
{
    public class StatViewModel : INotifyPropertyChanged
    {
        public RestCollection<Tire> Tires { get; set; }


        private List<string> data;
        public List<string> Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private Tire selectedTire;

        public Tire SelectedTire
        {
            get { return selectedTire; }
            set { selectedTire = value; }
        }


        public ICommand BrandAvaragesCommand { get; set; }

        public ICommand HqMadeOfPlaceCommand { get; set; }

        public ICommand TireRecommendationCommand { get; set; }
        public ICommand TirePriceSUMCommand { get; set; }
        public ICommand TireByDiameterCommand { get; set; }

        public string Price { get; set; }
        public string Width { get; set; }
        public string AspectRatio { get; set; }
        public string Diameter { get; set; }
        public string TireByDiameter { get; set; }
        public string ProductionCountryName { get; set; }
        public string TireName { get; set; }


        public StatViewModel()
        {
            
            RestService rest = new RestService("http://localhost:53910/", "swagger");
            BrandAvaragesCommand = new RelayCommand(() =>
            {
                var x = new List<string>();
                var q = rest.Get<AvarageResult>("Stat/AveragePerBrand");
                foreach (AvarageResult item in q)
                {
                    string temp = item.ToString();
                    x.Add(temp);
                }
                Data = x;
            });
            
            TirePriceSUMCommand = new RelayCommand(() =>
            {
                var x = new List<string>();
                var q = rest.Get<TirePriceSUM>("Stat/TirePriceSums");
                foreach (TirePriceSUM item in q)
                {
                    string temp = item.ToString();
                    x.Add(temp);
                }
                Data = x;
            });

            TireByDiameterCommand = new RelayCommand(() =>
            {
                var x = new List<string>();
                var q = rest.Get<TireByDiameter>("Stat/TireByDiameters?diameter=" + TireByDiameter);
                foreach (TireByDiameter item in q)
                {
                    string temp = item.ToString();
                    x.Add(temp);
                }
                Data = x;
            });

            //BrandAvaragesCommand = new RelayCommand(() => rest.Get<Brand>("stat/BrandAvarages"));


            TireRecommendationCommand = new RelayCommand(() =>
            {
                var x = new List<string>();
                var q = rest.Get<TireRecommendation>($"Stat/TireRecommendations?maxPrice={Price}&width={Width}&aspectRatio={AspectRatio}&diameter={Diameter}");
                foreach (TireRecommendation item in q)
                {
                    string temp = item.ToString();
                    x.Add(temp);
                }
                Data = x;
            });


            HqMadeOfPlaceCommand = new RelayCommand(() =>
            {
                var x = new List<string>();
                var q = rest.Get<HQMadeofPlace>($"Stat/HQMadeofPlaces?brandName={ProductionCountryName}&tireName={TireName}");
                foreach (HQMadeofPlace item in q)
                {
                    string temp = item.ToString();
                    x.Add(temp);
                }
                Data = x;
            });
            
                

        }
    }
}
