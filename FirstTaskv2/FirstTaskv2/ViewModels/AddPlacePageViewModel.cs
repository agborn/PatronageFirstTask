using FirstTaskv2.Classes;
using PatronageWP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FirstTaskv2.ViewModels
{
    public class AddPlacePageViewModel : INotifyPropertyChanged
    {
        public AddPlacePageViewModel()
        {
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            if (frame == null)
            {
                return;
            }

            if (frame.CanGoBack)
            {
                Cancel();
                e.Handled = true;
            }
        }

    
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
                //CanEnableAddButton();
                NotifyPropertyChanged("Place");
            }
        }

        PlaceService placeService = new PlaceService();
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
                            placeService.AddPlace(Place); Place = new Place();
                            NavigationService.Navigate(typeof(PlacesListPage));
                        }//, 
                        //() => 
                        //{
                         //   return CanEnableAddButton(); 
                        //}
                        ); 
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
                            Cancel();
                        });
                    
                }
                return clearCommand;
            }
        }

        private void Cancel()
        {
            var messageDialog = new MessageDialog("Do you want to cancel?");
            messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.ClearYesCommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("No", null));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;
            messageDialog.ShowAsync();
        }

        private void ClearYesCommandInvokedHandler(IUICommand command)
        {
            NavigationService.Navigate(typeof(PlacesListPage));
            Place.Name = String.Empty;
            Place.Address = String.Empty;
            Place.Geolocation();
            Place.HasWifi = false;
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }

        public bool CanEnableAddButton()
        {
            if (!string.IsNullOrWhiteSpace(Place.Name))
            {
                IsAddButtonEnabled = true;
                return true;
            }
            else
                IsAddButtonEnabled = false;
            return false;
        }

        private bool isAddButtonEnabled = true;
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
