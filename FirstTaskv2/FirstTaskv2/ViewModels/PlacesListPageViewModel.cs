using FirstTaskv2.Classes;
using PatronageWP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskv2.ViewModels
{
    public class PlacesListPageViewModel : INotifyPropertyChanged
    {
        private PlaceService placeService = new PlaceService();
        public PlacesListPageViewModel()
        {
            //poprzednia wersja - wyświetlanie listy lokalnej
            //Places = placeService.GetPlaces();
            getPlacesList();
        }

        private async void getPlacesList()
        {
            Places = await placeService.GetPlacesMobile();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private List<Place> places = new List<Place>();
        public List<Place> Places
        {
            get
            {
                return places;
            }
            set
            {
                places = value;
                NotifyPropertyChanged("Places");
            }
        }

        private NavigationService NavigationService = new NavigationService();
        private RelayCommand addCommand = null;
        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(
                        () =>
                        {
                            NavigationService.Navigate(typeof(AddPlacePage));
                        });
                }
                return addCommand;
            }
        }

        
    }
}
