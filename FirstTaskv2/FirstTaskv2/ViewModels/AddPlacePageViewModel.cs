using FirstTaskv2.ProjectClasses;
using PatronageWP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace FirstTaskv2.ViewModels
{
    public class AddPlacePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private Place place;
        public Place Place
        {
            get
            {
                return place;
            }
            set
            {
                place = value;
                place.Geolocation();
                NotifyPropertyChanged("Place");
            }
        }

        PlaceService placeService = new PlaceService();

        private RelayCommand addCommand = null;
        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(() =>
                    {
                        placeService.AddPlace(Place); Place = new Place();
                        var messageDialog = new MessageDialog(String.Format("Success. Number of places: {0}.", placeService.GetPlaces().Count));
                        messageDialog.ShowAsync();
                    });
                    
                }
                return addCommand;
            }
        }

        private RelayCommand clearCommand = null;
        public RelayCommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    
                    clearCommand = new RelayCommand(() =>
                        {
                            var messageDialog = new MessageDialog("Do you want to erase your data?");
                            messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)));
                            messageDialog.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.CommandInvokedHandler)));
                            messageDialog.DefaultCommandIndex = 0;
                            messageDialog.CancelCommandIndex = 1;
                            messageDialog.ShowAsync();
                        });
                    
                }
                return clearCommand;
            }
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            if (command.Label == "Yes")
            {
                Place.Name = String.Empty;
                Place.Address = String.Empty;
                Place.Latitude = 0;
                Place.Longitude = 0;
                Place.HasWifi = false;
            }
        }

        public void EnableAddButton( string Name)
        {
            if (Name != String.Empty)
                IsAddButtonEnabled = true;
            else
                IsAddButtonEnabled = false;
        }

        private bool isAddButtonEnabled;
        public bool IsAddButtonEnabled
        {
            get
            {
                return isAddButtonEnabled;
            }
            set
            {
                if (value != isAddButtonEnabled)
                {
                    isAddButtonEnabled = value;
                    NotifyPropertyChanged("IsAddButtonEnabled");
                }
            }
        }

    }
}
